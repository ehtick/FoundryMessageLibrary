namespace DTARServer.Models;

public class DT_Base
{
    public string guid;
	public string key;
	public string name;
	public string type;

	public string timeStamp;
    public string version;


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
		if (String.IsNullOrEmpty(version))
		{
			version = "v1.0.0";
		}
		return this;
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
public class DT_Hero : DT_Base
{
	public string title;
	public string description;
	public string parentKey;
	public DT_Document heroImage;

#if !UNITY
	public DT_Hero() : base()
	{
	}
#endif
}

