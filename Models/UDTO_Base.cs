namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Base
{
    static Guid defaultSourceGuid = Guid.NewGuid();
    public string udtoTopic { get; set; }
    public string sourceGuid { get; set; }
    public string timeStamp { get; set; }
    public string panID { get; set; }

    public UDTO_Base()
    {
        this.initialize(null);
    }

    public virtual string compress(char d = ',')
    {
        string g = sourceGuid;
        string t = timeStamp;
        string p = panID;
        string key = udtoTopic;
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
}
