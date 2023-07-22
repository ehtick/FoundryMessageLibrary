using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models
{


	public class DO_System : DO_Hero
	{
		public int memberCount { get; set; }
		public string systemName { get; set; }

		public List<DO_ProcessStep> steps;

	}

	[System.Serializable]
	public class DT_System : DT_Hero, ISystem
	{

		public int memberCount;
		public string systemName;

		public List<DT_Target> targets;


		public DT_System()
		{
		}

		public DT_System ShallowCopy()
		{
			var result = (DT_System)this.MemberwiseClone();
			result.targets = null;
			result.assetReferences = null;
			result.heroImage = this.heroImage;

			return result;
		}

	


	}
}


