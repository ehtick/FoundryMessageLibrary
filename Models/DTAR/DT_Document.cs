namespace DTARServer.Models;


[System.Serializable]
public class DT_Document : DT_Title
{
	public string filename;
	public string url;
	public string docType;

#if !UNITY
	public DT_Document() : base()
    {
    }
#endif
}


public class DT_Image : DT_Document
{
}




