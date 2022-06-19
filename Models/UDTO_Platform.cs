namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Platform : UDTO_3D
{
	public UDTO_Position position { get; set; }
	public BoundingBox boundingBox { get; set; }

	private readonly Dictionary<string, object> _lookup = new();


	public List<UDTO_Body> bodies
	{
		get
		{
			var lookup = FindLookup<UDTO_Body>();
			return lookup.Values.ToList();
		}
		set
		{
			if (value != null)
			{
				value.ForEach(item => Establish<UDTO_Body>(item, false));
			}
			else
			{
				var lookup = FindLookup<UDTO_Body>();
				lookup.Clear();
			}
		}
	}

	public List<UDTO_Label> labels
	{
		get
		{
			var lookup = FindLookup<UDTO_Label>();
			return lookup.Values.ToList();
		}
		set
		{
			if (value != null)
			{
				value.ForEach(item => Establish<UDTO_Label>(item, false));
			}
			else
			{
				var lookup = FindLookup<UDTO_Label>();
				lookup.Clear();
			}
		}
	}


	public List<UDTO_Relationship> relationships
	{
		get
		{
			var lookup = FindLookup<UDTO_Relationship>();
			return lookup.Values.ToList();
		}
		set
		{
			if (value != null)
			{
				value.ForEach(item => Establish<UDTO_Relationship>(item, false));
			}
			else
			{
				var lookup = FindLookup<UDTO_Relationship>();
				lookup.Clear();
			}
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
			Establish<UDTO_Body>(body);
		});
		platform.bodies = null;

		platform.labels.ForEach(label =>
		{
			Establish<UDTO_Label>(label);
		});
		platform.labels = null;

		platform.relationships.ForEach(relationship =>
		{
			Establish<UDTO_Relationship>(relationship);
		});
		platform.relationships = null;
	}


	public override string compress(char d = ',')
	{
		// Optional param in body compress function lets us use a semicolon instead of a comma as a delimeter 
		var bodies = this.bodies.Select(item => item.compress('!')).ToList();
		var bodycount = bodies.Count;
		var platform = $"{base.compress(d)}{d}{position?.compress(d)}{d}{boundingBox?.compress(d)}";
		if (bodycount > 0)
		{
			var body = bodies.First();
			var rest = String.Join(",", bodies);
			return $"{platform},{rest}";
		}

		return platform;
	}
	public override int decompress(string[] data)
	{
		var counter = base.decompress(data);

		platformName = data[counter++];

		if (data[counter] != String.Empty)
		{
			position = new UDTO_Position();
			var seg = new ArraySegment<string>(data, counter, data.Length - counter);
			counter += position.decompress(seg.ToArray());
		}
		else
		{
			counter++;
		}

		if (data[counter] != String.Empty)
		{
			boundingBox = new BoundingBox();
			var seg = new ArraySegment<string>(data, counter, data.Length - counter);
			counter += boundingBox.decompress(seg.ToArray());
		}
		else
		{
			counter++;
		}

		// Now rehydrate all the bodies 
		// Bodies are separated by commas, but internal fields are separated by semicolons
		// At this point counter is pointing to the first body in the data array, every element following it is also a body up to data.Length-1
		while (counter != data.Length)
		{
			var body = new UDTO_Body();
			var segment = data[counter];
			var rest = segment.Split('!');
			body.decompress(rest);
			Establish<UDTO_Body>(body);
			counter++;
		}
		return counter;
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

	public T FindOrCreate<T>(string name, bool create) where T: UDTO_3D
	{
		var dict = FindLookup<T>();
		if (!dict.TryGetValue(name, out T found) && create)
		{
			found = Activator.CreateInstance<T>();
			found.name = name;
			found.panID = panID;
			found.platformName = platformName;
			uniqueGuid = Guid.NewGuid().ToString();
			dict[name] = found;
		}
		return found;
	}

	public T Establish<T>(T obj, bool delete = false) where T : UDTO_3D
	{
		var key = obj.name;
		var dict = FindLookup<T>();
		if (dict.TryGetValue(key, out T found))
		{
			found.CopyFrom(obj);

			if (delete)
			{
				dict.Remove(key);
			}
		}
		else if (!delete)
		{
			dict[key] = obj;
			found = obj;
		}
		return found;
	}

}

