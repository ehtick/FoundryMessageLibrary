namespace DTARServer.Models;

[System.Serializable]
public class DT_Document : DT_Artifact
{
    public string url;
    public string docType;


    public DT_Document() : base()
    {
    }

}

public class DT_Link : DT_Document
{
}
public class DT_Dwg : DT_Document
{

}
public class DT_RemoteLink : DT_Document
{
}


