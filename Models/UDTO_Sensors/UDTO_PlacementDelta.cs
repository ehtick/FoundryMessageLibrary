
using FoundryRulesAndUnits.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{




	[System.Serializable]
	public class UDTO_PlacementDelta : UDTO_SensorBase
	{
		public HighResPosition placement;
	}
}