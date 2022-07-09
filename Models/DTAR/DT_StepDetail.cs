namespace DTARServer.Models;

[System.Serializable]
public class DT_StepDetail : DT_Hero
{
	public int itemNumber;

	public List<DT_AssetReference> assetReferences;

#if !UNITY
    public DT_StepDetail() : base()
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



	public DT_StepDetail ShallowCopy()
	{
		var result = (DT_StepDetail)this.MemberwiseClone();
		result.assetReferences = new List<DT_AssetReference>();
		return result;
	}

#endif
}


[System.Serializable]
public class DT_Note : DT_StepDetail
{

}

[System.Serializable]
public class DT_Caution : DT_StepDetail
{
}

[System.Serializable]
public class DT_Warning : DT_StepDetail
{
}

[System.Serializable]
public class DT_StepAction : DT_StepDetail
{
}
