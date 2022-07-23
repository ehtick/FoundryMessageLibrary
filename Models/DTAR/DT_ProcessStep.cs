namespace DTARServer.Models;
using System.Linq;

[System.Serializable]
public class DT_ProcessStep : DT_Hero
{
	public int stepNumber;

	public List<DT_StepDetail> details;


#if !UNITY
    public DT_ProcessStep() : base()
    {
    }

    public T AddStepDetail<T>(T detail) where T : DT_StepDetail
	{
        if (details == null)
        {
			details = new List<DT_StepDetail>();
        }
		detail.parentGuid = this.guid;

		details.Add(doc);

		details = details.OrderBy(x => x.itemNumber).ToList();
        return detail;
    }



	public override List<DT_Document> CollectDocuments(List<DT_Document> list)
	{
		base.CollectDocuments(list);

		details?.ForEach(step => {
			step.CollectDocuments(list);
		});
		return list;
	}

	public DT_ProcessStep ShallowCopy()
	{
		var result = (DT_ProcessStep)this.MemberwiseClone();
		result.assetReferences = null;
		result.details = result.details?.Select(obj => obj.ShallowCopy()).ToList();
		result.ClearKeys();
		result.DeReference();
		return result;
	}

#endif
}
