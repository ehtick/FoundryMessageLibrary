namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Platform : UDTO_3D
{
	public UDTO_Position position;
	public BoundingBox boundingBox;

	private readonly Dictionary<string, object> _lookup = new();
	private readonly Dictionary<string, UDTO_3D> _guids = new();

#if UNITY
	public List<UDTO_Body> bodies;
	public List<UDTO_Label> labels;
	public List<UDTO_Relationship> relationships;
#endif

#if !UNITY
	public List<UDTO_Body> bodies
	{
		get
		{
			return FindList<UDTO_Body>();
		}
		set
		{
			if (value != null)
				value.ForEach(item => AddRefreshOrDelete<UDTO_Body>(item, false));
			else
				ClearLookup<UDTO_Body>();
		}
	}



	public List<UDTO_Label> labels
	{
		get
		{
			return FindList<UDTO_Label>();
		}
		set
		{
			if (value != null)
				value.ForEach(item => AddRefreshOrDelete<UDTO_Label>(item, false));
			else
				ClearLookup<UDTO_Label>();
		}
	}


	public List<UDTO_Relationship> relationships
	{
		get
		{
			return FindList<UDTO_Relationship>();
		}
		set
		{
			if (value != null)
				value.ForEach(item => AddRefreshOrDelete<UDTO_Relationship>(item, false));
			else
				ClearLookup<UDTO_Relationship>();
		}
	}


	public void Merge(UDTO_Platform platform)
	{
		if (platform.position != null)
		{
			this.position = platform.position;
		}
		if (platform.boundingBox != null)
		{
			this.boundingBox = platform.boundingBox;
		}

		platform.bodies.ForEach(body =>
		{
			AddRefreshOrDelete<UDTO_Body>(body);
		});
		platform.bodies = null;

		platform.labels.ForEach(label =>
		{
			AddRefreshOrDelete<UDTO_Label>(label);
		});
		platform.labels = null;

		platform.relationships.ForEach(relationship =>
		{
			AddRefreshOrDelete<UDTO_Relationship>(relationship);
		});
		platform.relationships = null;
	}


	public UDTO_Platform SetPositionTo(UDTO_Position loc)
	{
		position = loc;
		return this;
	}

	public UDTO_Platform()
	{
		CreateLookup<UDTO_Body>();
		CreateLookup<UDTO_Label>();
		CreateLookup<UDTO_Relationship>();

		uniqueGuid = Guid.NewGuid().ToString();
		type = "Platform";
	}

	public UDTO_Platform AsShallowCopy()
	{
		var platform = new UDTO_Platform()
		{
			sourceGuid = this.sourceGuid,
			timeStamp = this.timeStamp,
			panID = this.panID,
			platformName = this.platformName,
			uniqueGuid = this.uniqueGuid,
			type = this.type,
			name = this.name,
			position = this.position,
			boundingBox = this.boundingBox
		};
		return platform;
	} 

	public U RelateMembers<U>(UDTO_3D source, string name, UDTO_3D target) where U : UDTO_Relationship
	{
		var tag = $"{source.uniqueGuid}:{name}";
		var relationship = Find<U>(tag);
		if (relationship == null )
		{
			relationship = FindOrCreate<U>(tag,true);
			relationship.Build(source.uniqueGuid, name, target.uniqueGuid);
		} 
		else
		{
			relationship.Relate(target.uniqueGuid);
		}

		return relationship;
	}

	public U UnrelateMembers<U>(UDTO_3D source, string name, UDTO_3D target) where U : UDTO_Relationship
	{
		var tag = $"{source.uniqueGuid}:{name}";
		var relationship = Find<U>(tag);
		if (relationship != null)
			relationship.Unrelate(target.uniqueGuid);

		return relationship;
	}

	private Dictionary<string,T> CreateLookup<T>() where T:UDTO_3D 
	{
		var result = new Dictionary<string, T>();
		_lookup.Add(typeof(T).Name, result);
		return result;
	}
	private Dictionary<string, T> FindLookup<T>() where T : UDTO_3D
	{
		var result = _lookup[typeof(T).Name] as Dictionary<string, T>;
		return result;
	}

	public List<T> FindList<T>() where T : UDTO_3D
	{
		var lookup = FindLookup<T>();
		return lookup.Values.ToList();
	}

	private void ClearLookup<T>() where T : UDTO_3D
	{
		var result = _lookup[typeof(T).Name] as Dictionary<string, T>;
		result.Clear();
	}

	private T CreateItem<T>(string name) where T : UDTO_3D
	{
		var found = Activator.CreateInstance<T>() as T;
		found.name = name;
		found.panID = panID;
		found.platformName = platformName;
		found.uniqueGuid = Guid.NewGuid().ToString();
		_guids[found.uniqueGuid] = found;
		return found;
	}

	public T Find<T>(string name) where T : UDTO_3D
	{
		var dict = FindLookup<T>();
		dict.TryGetValue(name, out T found);
		return found;
	}

	public T FindOrCreate<T>(string name, bool create=false) where T: UDTO_3D
	{
		var dict = FindLookup<T>();
		if (!dict.TryGetValue(name, out T found) && create)
		{
			found = CreateItem<T>(name);
			dict[name] = found;
		}
		return found;
	}

	public T AddRefreshOrDelete<T>(T obj, bool delete = false) where T : UDTO_3D
	{
		var key = obj.name;
		var dict = FindLookup<T>();
		if (dict.TryGetValue(key, out T found))
		{
			if (delete)
			{
				dict.Remove(key);
				_guids.Remove(found.uniqueGuid);
			} 
			else
			{
				found.CopyFrom(obj);
				_guids[found.uniqueGuid] = found;
			}
		}
		else if (!delete)
		{
			dict[key] = obj;
			found = obj;
			_guids[found.uniqueGuid] = found;
		}
		return found;
	}
#endif
}

