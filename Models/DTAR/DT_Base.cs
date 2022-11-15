using System;

namespace IoBTMessage.Models
{
	public class DT_Base
	{
		public string guid;
		public string parentGuid;
		public string name;
		public string type;

		public string timeStamp;

		public ControlParameters metadata;


#if !UNITY
		public DT_Base()
		{
			this.initialize();
		}
		public DT_Base(string name)
		{
			this.name = name;
			this.initialize();
		}
		public virtual T merge<T>(T obj) where T: DT_Base 
		{
			if ( this.timeStamp.CompareTo(obj.timeStamp) < 0) {
				this.timeStamp = obj.timeStamp;
			}
			return this as T;
		}

		public string resetTimeStamp()
		{
			this.timeStamp = DateTime.UtcNow.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
			return this.timeStamp;
		}

		public static string asTopic(string name)
		{
			return name.Replace("DT_", "");
		}

		public static string asTopic<T>() where T : DT_Base
		{
			return DT_Base.asTopic(typeof(T).Name);
		}

		public static string asTopicLower<T>() where T : DT_Base
		{
			return DT_Base.asTopic(typeof(T).Name).ToLower();
		}


		public ControlParameters MetaData()
		{
			metadata ??= new ControlParameters();
			return metadata;
		}

		public ControlParameters AddMetaData(string key, string value)
		{
			MetaData().Establish(key,value);
			return metadata;
		}
		
		public DT_Base initialize()
		{
			if (String.IsNullOrEmpty(type))
			{
				type = DT_Base.asTopic(this.GetType().Name);
			}
			if (String.IsNullOrEmpty(timeStamp))
			{
				resetTimeStamp();
			}
			if (String.IsNullOrEmpty(guid))
			{
				guid = Guid.NewGuid().ToString();
			}
			return this;
		}


#endif
	}

	public interface ISystem
	{

	}

	[System.Serializable]
	public class DT_Searchable : DT_Base
	{
		public string title;
		public string description;
		
#if !UNITY
		public DT_Searchable() : base()
		{
		}
#endif
	}



	[System.Serializable]
	public class DT_Error : DT_Base
	{
		public string error;
		public object source;

#if !UNITY
		public DT_Error() : base()
		{
		}
#endif
	}

	[System.Serializable]
	public class DT_QualityAssurance : DT_Searchable
	{
		public string action;
		public string author;
		public string componentGuid;

#if !UNITY
		public DT_QualityAssurance() : base()
		{
		}
#endif
	}

	[System.Serializable]
	public class DT_Comment : DT_Searchable
	{
		public string severity;
		public string author;

#if !UNITY
		public DT_Comment() : base()
		{
		}
		public DT_Comment OK()
		{
			severity = "OK";
			return this;
		}
		public DT_Comment Error()
		{
			severity = "Error";
			return this;
		}
		public DT_Comment Bug()
		{
			severity = "Bug";
			return this;
		}
		public DT_Comment Comment()
		{
			severity = "Comment";
			return this;
		}
		public DT_Comment MissingReference()
		{
			severity = "Missing";
			return this;
		}
#endif
	}
}
