namespace DTARServer.Models;

[System.Serializable]
public class DT_AssetReference : DT_Base
{
    public string assetGUID;
    public List<string> parameters = new();
	public DT_Document document;

#if !UNITY
	public DT_AssetReference() : base()
	{
	}
	public virtual void DeReference()
	{
		assetGUID = document?.guid ?? assetGUID;
		document = null;
	}
	public DT_AssetReference ShallowCopy()
	{
		var result = (DT_AssetReference)this.MemberwiseClone();
		result.DeReference();
		return result;
	}
#endif
}
