using System.Collections.Generic;
using System.Linq;
using IoBTMessage.Extensions;

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
		public void Flush()
		{
			targets = new();
			links = new();
		}
		public List<DT_Target> AddTarget(DT_Target target)
		{
			targets ??= new List<DT_Target>();
			if (target != null)
				targets.Add(target);

			return targets;
		}
		public List<DT_Target> Targets()
		{
			targets ??= new List<DT_Target>();
			return targets;
		}
		public List<DT_TargetLink> Links()
		{
			links ??= new List<DT_TargetLink>();
			return links;
		}

		public DT_Target FindTarget(string type, string controlNumber)
		{
			var found  = targets?.FirstOrDefault(t => t.targetType.Matches(type)  && t.controlNumber.Matches(controlNumber));
			return found;
		}
		public (DT_Target, DT_Target)  ResolveLink(DT_TargetLink link)
		{
			var source = targets?.FirstOrDefault(t => link.sourceGuid.Matches(t.guid));
			var sink = targets?.FirstOrDefault(t => link.sinkGuid.Matches(t.guid));
			return (source, sink);
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


