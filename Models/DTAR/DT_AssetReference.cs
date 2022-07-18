namespace DTARServer.Models;

[System.Serializable]
public class DT_AssetReference : DT_Base
{
    public string assetGUID;
    public List<string> parameters = new();
	public DT_Document document;
}
