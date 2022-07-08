namespace DTARServer.Models;

public class DT_Base : DTAR_Base
{
    public string guid;
    public string key;
    public string description;
    public string version;


#if !UNITY
    public DT_Base() : base()
    { 
        guid = Guid.NewGuid().ToString();
        version = "v1.0.0";
     }
#endif
}

[System.Serializable]
public class DT_Error : DT_Base
{
    public string error;
    public object source;

    public DT_Error() : base()
    {
    }
}

