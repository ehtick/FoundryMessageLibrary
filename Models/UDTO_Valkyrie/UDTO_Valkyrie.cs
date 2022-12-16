
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

//Danger, Safe, Warning, Suspend, OffLine


namespace IoBTMessage.Models
{

	public class SPEC_Valkyrie  : SPEC_Base
	{
		public SPEC_ValkyrieZone zone { get; set; }
		public SPEC_ValkyrieSystem system { get; set; }
		public SPEC_ValkyrieThreats threats { get; set; }
		public SPEC_ValkyrieDevices devices { get; set; }

		public static SPEC_Valkyrie RandomSpec() {
			return new SPEC_Valkyrie()
			{
			};
		}
	}

	[System.Serializable]
	public class UDTO_Valkyrie  : UDTO_Base
	{
		public ValkyrieZone zone;
		public ValkyrieSystem system;
		public ValkyrieThreats threats;
		public ValkyrieDevices devices;
	}
}