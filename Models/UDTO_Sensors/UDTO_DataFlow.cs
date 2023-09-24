
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using FoundryRulesAndUnits.Models;
using FoundryRulesAndUnits.Units;

namespace IoBTMessage.Models
{

	public class SPEC_DataFlow : SPEC_SensorBase
	{
		public DataFlow rate { get; set; }


		public static SPEC_DataFlow RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_DataFlow()
			{
				rate = new DataFlow(gen.GenerateDouble(60, 90)),
			};
		}
	}

	[System.Serializable]
	public class UDTO_DataFlow : UDTO_SensorBase
	{
		public DataFlow rate;
	}
}