
using FoundryRulesAndUnits.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{




	[System.Serializable]
	public class UDTO_Size : UDTO_SensorBase
	{
		public BoundingBox size;
	}
}