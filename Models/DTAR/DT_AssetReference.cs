namespace DTARServer.Models;

[System.Serializable]
public class DT_AssetReference : DT_Base
{
    public string assetGUID;
    public string SheetStart;
    public string SheetEnd;
    public DT_Document document;

}
