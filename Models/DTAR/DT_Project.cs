using System.Collections.Generic;

namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_Project : DT_Hero
	{
		public int memberCount;
		public List<DT_ProcessPlan> processPlans;



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
			this.memberCount = processPlans.Count;

			return plan;
		}



		public override List<DT_Document> CollectDocuments(List<DT_Document> list, bool deep)
		{
			base.CollectDocuments(list,deep);
			if ( !deep) return list;

			processPlans?.ForEach(plan =>
			{
				plan.CollectDocuments(list,deep);
			});
			return list;
		}

		public override List<DT_AssetReference> CollectAssetReferences(List<DT_AssetReference> list, bool deep)
		{
			base.CollectAssetReferences(list,deep);
			if ( !deep) return list;
			
			processPlans?.ForEach(plan =>
			{
				plan.CollectAssetReferences(list,deep);
			});

			return list;
		}

		public override List<DT_ComponentReference> CollectComponentReferences(List<DT_ComponentReference> list, bool deep)
		{
			base.CollectComponentReferences(list,deep);
			if ( !deep) return list;

			processPlans?.ForEach(plan =>
			{
				plan.CollectComponentReferences(list,deep);
			});
			return list;
		}

		public override List<DT_Comment> CollectComments(List<DT_Comment> list)
		{
			base.CollectComments(list);

			processPlans?.ForEach(plan =>
			{
				plan.CollectComments(list);
			});
			return list;
		}

		public override List<DT_QualityAssurance> CollectQualityAssurance(List<DT_QualityAssurance> list)
		{
			base.CollectQualityAssurance(list);

			processPlans?.ForEach(plan =>
			{
				plan.CollectQualityAssurance(list);
			});
			return list;
		}

		public DT_Project ShallowCopy()
		{
			var result = (DT_Project)this.MemberwiseClone();
			result.processPlans = null;
			result.assetReferences = null;

			return result;
		}

	}
}

