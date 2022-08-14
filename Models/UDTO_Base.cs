
using System;

namespace IoBTMessage.Models
{

	[System.Serializable]
	public class UDTO_Base
	{
		static Guid defaultSourceGuid = Guid.NewGuid();
		public string udtoTopic;
		public string sourceGuid;
		public string timeStamp;
		public string panID;

#if !UNITY
		public UDTO_Base()
		{
			this.initialize(null);
		}

		public T Duplicate<T>() where T : UDTO_Base
		{
			var dupe = Activator.CreateInstance<T>();
			dupe.decompress(this.compress().Split(','));
			return dupe;
		}

		public string compareHash()
		{
			var hash = this.compress();
			var list = hash.Split('\u002C');
			list[2] = "NOTIME";
			var key = string.Join('\u002C', list);
			return key;
		}

		public virtual string compress(char d = '\u002C')
		{
			var g = sourceGuid;
			var t = timeStamp;
			var p = panID;
			var key = udtoTopic;
			return $"{key}{d}{g}{d}{t}{d}{p}";
		}

		public virtual int decompress(string[] data)
		{
			int counter = 1;
			this.sourceGuid = data[counter++];
			this.timeStamp = data[counter++];
			this.panID = data[counter++];
			return counter;
		}

		public string resetTimeStamp()
		{
			this.timeStamp = DateTime.UtcNow.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
			return this.timeStamp;
		}

		public static string asTopic(string name)
		{
			return name.Replace("UDTO_", "");
		}

		public static string asTopic<T>() where T : UDTO_Base
		{
			return UDTO_Base.asTopic(typeof(T).Name);
		}

		public static string asTopicLower<T>() where T : UDTO_Base
		{
			return UDTO_Base.asTopic(typeof(T).Name).ToLower();
		}

		public T sync<T>() where T : UDTO_Base
		{
			if (String.IsNullOrEmpty(udtoTopic))
			{
				udtoTopic = UDTO_Base.asTopic(this.GetType().Name);
			}
			return this as T;
		}

		public UDTO_Base initialize(string defaultPanID)
		{
			if (String.IsNullOrEmpty(udtoTopic))
			{
				udtoTopic = UDTO_Base.asTopic(this.GetType().Name);
			}
			if (String.IsNullOrEmpty(timeStamp))
			{
				resetTimeStamp();
			}
			if (String.IsNullOrEmpty(sourceGuid))
			{
				sourceGuid = UDTO_Base.defaultSourceGuid.ToString();
			}
			if (String.IsNullOrEmpty(panID))
			{
				panID = defaultPanID;
			}
			return this;
		}

		public virtual string getUniqueCode()
		{
			return $"{this.udtoTopic}{this.sourceGuid}{this.timeStamp}{this.panID}";
		}

		public virtual bool matches(UDTO_Base other)
		{
			return this.getUniqueCode() == other.getUniqueCode();
		}
#endif
	}
}