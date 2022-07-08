// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
using System;
namespace DTARServer.Models;

[System.Serializable]
public class DTAR_Base
{
    public string name { get; set; }
    public string type { get; set; }
    public string timeStamp { get; set; }

    public DTAR_Base()
    {
        this.initialize();
    }

    public DTAR_Base(string name)
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

    public static string asTopic<T>() where T : DTAR_Base
    {
        return DTAR_Base.asTopic(typeof(T).Name);
    }

    public static string asTopicLower<T>() where T : DTAR_Base
    {
        return DTAR_Base.asTopic(typeof(T).Name).ToLower();
    }

    //public T sync<T>() where T : DTAR_Base
    //{
    //    if (String.IsNullOrEmpty(tmssTopic))
    //    {
    //        tmssTopic = DTAR_Base.asTopic(this.GetType().Name);
    //    }
    //    return this as T;
    //}

    public DTAR_Base initialize()
    {
        if (String.IsNullOrEmpty(type))
        {
            type = DTAR_Base.asTopic(this.GetType().Name);
        }
        if (String.IsNullOrEmpty(timeStamp))
        {
            resetTimeStamp();
        }
        return this;
    }
}
