namespace DTARServer.Models;

[System.Serializable]
public class DT_ProcessStep : DT_Hero
{
	public int stepNumber;

	public List<DT_StepDetail> details;
	public List<DT_AssetReference> assetReferences;

#if !UNITY
    public DT_ProcessStep() : base()
    {
    }

    public T AddStepDetail<T>(T doc) where T : DT_StepDetail
	{
        if (details == null)
        {
			details = new List<DT_StepDetail>();
        }
		details.Add(doc);

		details = details.OrderBy(x => x.itemNumber).ToList();
        return doc;
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
