namespace DTARServer.Models;

[System.Serializable]
public class DT_ProcessPlan : DT_Hero
{
	public List<DT_AssetReference> assetReferences;
    public List<DT_ProcessStep> steps;


#if !UNITY
    public DT_ProcessPlan()
    {
    }

    public T AddStep<T>(T step) where T : DT_ProcessStep
    {
        if (steps == null)
        {
            steps = new List<DT_ProcessStep>();
        }
        steps.Add(step);
		steps = steps.OrderBy(x => x.sortKey).ToList();

		return step;
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



    public DT_ProcessPlan ShallowCopy()
    {
        var result = (DT_ProcessPlan)this.MemberwiseClone();
        result.steps = new List<DT_ProcessStep>();
        result.assetReferences = new List<DT_AssetReference>();
        return result;
    }
#endif
}


