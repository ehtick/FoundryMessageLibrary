
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{


	public class SPEC_IMUReading : SPEC_SensorBase
	{

		public SPEC_HighResVector acc;
		public SPEC_HighResVector gyro;
		public SPEC_HighResVector mag;
	}

	[System.Serializable]
	public class UDTO_IMUReading
	{
		public HighResVector acc;
		public HighResVector gyro;
		public HighResVector mag;
	}
}