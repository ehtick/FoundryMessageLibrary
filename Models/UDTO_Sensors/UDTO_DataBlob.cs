
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using FoundryRulesAndUnits.Models;
using FoundryRulesAndUnits.Units;

namespace IoBTMessage.Models
{

	public class SPEC_DataBlob : SPEC_SensorBase
	{
		public DataStorage size { get; set; }


		public static SPEC_DataBlob RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_DataBlob()
			{
				size = new DataStorage(gen.GenerateDouble(60, 90)),
			};
		}
	}

	[System.Serializable]
	public class UDTO_DataBlob : UDTO_SensorBase
	{
		public DataStorage size;
	}
}