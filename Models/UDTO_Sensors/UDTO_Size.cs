
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{


	public class SPEC_Size : SPEC_SensorBase
	{
		public SPEC_BoundingBox size { get; set; }
	}

	[System.Serializable]
	public class UDTO_Size : UDTO_SensorBase
	{
		public BoundingBox size;
	}
}