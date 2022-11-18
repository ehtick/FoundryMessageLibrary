using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models
{


	[System.Serializable]
	public class DT_ProcessPlan : DT_Hero, ISystem
	{

		public int memberCount;
		public string systemName;
		public string distribution;
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
			this.memberCount = steps.Count;
			return step;
		}


		public override List<DT_Document> CollectDocuments(List<DT_Document> list)
		{
			base.CollectDocuments(list);


			steps?.ForEach(step =>
			{
				step.CollectDocuments(list);
			});
			return list;
		}

		public override List<DT_AssetReference> CollectAssetReferences(List<DT_AssetReference> list)
		{
			base.CollectAssetReferences(list);
			
			steps?.ForEach(step =>
			{
				step.CollectAssetReferences(list);
			});

			return list;
		}

		public override List<DT_ComponentReference> CollectComponentReferences(List<DT_ComponentReference> list)
		{
			base.CollectComponentReferences(list);

			steps?.ForEach(step =>
			{
				step.CollectComponentReferences(list);
			});
			return list;
		}

		public override List<DT_Comment> CollectComments(List<DT_Comment> list)
		{
			base.CollectComments(list);

			steps?.ForEach(step =>
			{
				step.CollectComments(list);
			});
			return list;
		}

		public override List<DT_QualityAssurance> CollectQualityAssurance(List<DT_QualityAssurance> list)
		{
			base.CollectQualityAssurance(list);

			steps?.ForEach(step =>
			{
				step.CollectQualityAssurance(list);
			});
			return list;
		}

		public DT_ProcessPlan ShallowCopy()
		{
			var result = (DT_ProcessPlan)this.MemberwiseClone();
			result.steps = null;
			result.assetReferences = null;

			return result;
		}

		public List<DT_ProcessStep> ShallowSteps()
		{
			var result = steps?.Select(obj => obj.ShallowCopy()).ToList();
			return result;
		}

#endif
	}
}


