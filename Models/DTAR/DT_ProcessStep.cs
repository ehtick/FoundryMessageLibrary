namespace DTARServer.Models;

[System.Serializable]
public class DT_ProcessStep : DT_Hero
{
	public int stepNumber;
	public int itemNumber;
	public double sortKey;

	public List<DT_AssetReference> assetReferences;

#if !UNITY
    public DT_ProcessStep() : base()
    {
    }

    public T AddReference<T>(T doc) where T : DT_AssetReference
    {
        if (assetReferences == null)
        {
            assetReferences = new List<DT_AssetReference>();
        }
        assetReferences.Add(doc);
        return doc;
    }



	public DT_ProcessStep ShallowCopy()
	{
		var result = (DT_ProcessStep)this.MemberwiseClone();
		result.assetReferences = new List<DT_AssetReference>();
		return result;
	}

#endif
}


[System.Serializable]
public class DT_Note : DT_ProcessStep
{

}

[System.Serializable]
public class DT_Caution : DT_ProcessStep
{
}

[System.Serializable]
public class DT_Warning : DT_ProcessStep
{
}

[System.Serializable]
public class DT_Step : DT_ProcessStep
{
}
