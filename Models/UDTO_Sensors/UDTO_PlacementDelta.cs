
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{


	public class SPEC_PlacementDelta : SPEC_SensorBase
	{
		public SPEC_HighResPosition placement { get; set; }
	}

	[System.Serializable]
	public class UDTO_PlacementDelta : UDTO_SensorBase
	{
		public HighResPosition placement { get; set; }
	}
}