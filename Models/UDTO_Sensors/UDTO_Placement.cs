
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{


	public class SPEC_Placement : SPEC_SensorBase
	{
		public SPEC_HighResPosition placement { get; set; }
	}

	[System.Serializable]
	public class UDTO_Placement : UDTO_SensorBase
	{
		public HighResPosition placement;
	}
}