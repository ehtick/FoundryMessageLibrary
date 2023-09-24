
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using FoundryRulesAndUnits.Models;
using FoundryRulesAndUnits.Units;


// What do I always want to know about the weapon?
// When it is brought up to "low ready"
// When it is brought up to "high ready"
// When it fires (and I want to calculate remaining ammo)
// When there is a mag change
// Where is is pointing (pretty much always because there could be accidental discharge incidents even in training, and we can help pinpoint what went wrong after action, etc)
// When the VictoR recognizes a target
// Estimated range to target (I want to try to calculate where that target goes on my COP)
// Recognition data from the target after a shot (what did we just hit? DID we hit?)

namespace IoBTMessage.Models
{

	public class SPEC_System : SPEC_SensorBase
	{
		public Percent cpuUsage { get; set; }
		public double cpuSize { get; set; }
		public Percent memoryUsage { get; set; }
		public DataStorage memorySize { get; set; }
		public Percent diskUsage { get; set; }
		public DataStorage diskSize { get; set; }

		public static SPEC_System RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_System()
			{
				cpuUsage = new Percent(gen.GenerateDouble(0, 100)),
				cpuSize = gen.GenerateDouble(0, 1),
				memoryUsage = new Percent(gen.GenerateDouble(0, 100)),
				memorySize = new DataStorage(gen.GenerateDouble(0, 1)),
				diskUsage = new Percent(gen.GenerateDouble(0, 100)),
				diskSize = new DataStorage(gen.GenerateDouble(0, 1)),
			};
		}
	}

	[System.Serializable]
	public class UDTO_System : UDTO_SensorBase
	{
		public Percent cpuUsage;
		public double cpuSize;
		public Percent memoryUsage;
		public DataStorage memorySize;
		public Percent diskUsage;
		public DataStorage diskSize;
	}
}