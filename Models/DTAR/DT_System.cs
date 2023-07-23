using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models
{



	[System.Serializable]
	public class DT_System : DT_Hero, ISystem
	{

		public int memberCount;
		public string systemName;

		public List<DT_Target> targets;
		public List<DT_TargetLink> links;

		public DT_System()
		{
		}

		public DT_System ShallowCopy()
		{
			var result = (DT_System)this.MemberwiseClone();
			result.targets = null;
			result.links = null;
			result.assetReferences = null;
			result.heroImage = this.heroImage;

			return result;
		}

		public List<DT_Target> AddTarget(DT_Target target)
		{
			targets ??= new List<DT_Target>();
			if (target != null)
				targets.Add(target);

			return targets;
		}

		public List<DT_TargetLink> AddLink(DT_TargetLink link)
		{
			links ??= new List<DT_TargetLink>();
			if (link != null)
				links.Add(link);

			return links;
		}
	}
}


