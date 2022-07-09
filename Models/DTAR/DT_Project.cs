using System.Text.Json.Serialization;
namespace DTARServer.Models;

[System.Serializable]
public class DT_Project : DT_Hero
{
	public string system;
    public List<DT_ProcessPlan> processPlans;
	public List<DT_AssetReference> assetReferences;

#if !UNITY
	public DT_Project() : base()
    {
    }

    public DT_ProcessPlan AddProcessPlan(DT_ProcessPlan plan)
    {
        if (processPlans == null)
        {
            processPlans = new List<DT_ProcessPlan>();
        }
		plan.parentKey = this.key;

		processPlans.Add(plan);
        return plan;
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



    public DT_Project ShallowCopy()
    {
        var result = (DT_Project)this.MemberwiseClone();
        result.processPlans = new List<DT_ProcessPlan>();
		result.assetReferences = new List<DT_AssetReference>();
		return result;
    }
#endif
}


