
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{


	public class SPEC_IMUReading : SPEC_SensorBase
	{
		public SPEC_HighResVector acc { get; set; }
		public SPEC_HighResVector gyro { get; set; }
		public SPEC_HighResVector mag { get; set; }
	}

	[System.Serializable]
	public class UDTO_IMUReading : UDTO_SensorBase
	{
		public HighResVector acc;
		public HighResVector gyro;
		public HighResVector mag;
	}
}