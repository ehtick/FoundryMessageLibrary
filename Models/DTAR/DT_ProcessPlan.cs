namespace DTARServer.Models;
using DTARServer;

[System.Serializable]
public class DT_ProcessPlan : DT_Hero
{
    public List<DT_ProcessStep> steps;


#if !UNITY
	public DT_ProcessPlan()
    {
    }

    public DT_ProcessStep AddProcessStep(DT_ProcessStep step)
    {
        if (steps == null)
        {
            steps = new List<DT_ProcessStep>();
        }
		step.parentGuid = this.guid;

		steps.Add(step);
		return step;
    }


	public override List<DT_Document> CollectDocuments(List<DT_Document> list)
	{
		base.CollectDocuments(list);


		steps?.ForEach(step => {
			step.CollectDocuments(list);
		});
		return list;
	}

	public DT_ProcessPlan ShallowCopy()
    {
        var result = (DT_ProcessPlan)this.MemberwiseClone();
        result.steps = null;
		result.assetReferences = null;
		result.ClearKeys();
		result.DeReference();
		return result;
    }

	public List<DT_ProcessStep> ShallowSteps()
	{
		var result = steps?.Select(obj => obj.ShallowCopy()).ToList();
		return result;
	}

#endif
}


