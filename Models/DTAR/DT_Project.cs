using System.Text.Json.Serialization;
namespace DTARServer.Models;

[System.Serializable]
public class DT_Project : DT_Hero
{
	public string system;
    public List<DT_ProcessPlan> processPlans;


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
		plan.parentGuid = this.guid;

		processPlans.Add(plan);
        return plan;
    }



	public override List<DT_Document> CollectDocuments(List<DT_Document> list)
	{
		base.CollectDocuments(list);

		processPlans?.ForEach(plan => {
			plan.CollectDocuments(list);
		});
		return list;
	}

	public DT_Project ShallowCopy()
    {
        var result = (DT_Project)this.MemberwiseClone();
		result.processPlans = null;
		result.assetReferences = null;
		result.DeReference();
		return result;
    }

#endif
}


