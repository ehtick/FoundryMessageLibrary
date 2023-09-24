
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

	public class SPEC_Electrical  : SPEC_SensorBase
	{
		public Voltage voltage { get; set; }
		public Current current { get; set; }
		public Resistance resistance { get; set; }
		public Power wattage { get; set; }
		public Capacitance capacitance { get; set; }
		public Temperature temperature { get; set; }

		public static SPEC_Electrical RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_Electrical()
			{
				voltage = new Voltage(gen.GenerateDouble(60, 90)),
				current = new Current(gen.GenerateDouble(97.8, 99.3)),
				resistance = new Resistance(gen.GenerateDouble(1260, 9010)),
				wattage = new Power(gen.GenerateDouble(60, 90)),
				capacitance = new Capacitance(gen.GenerateDouble(97.8, 99.3)),
				temperature = new Temperature(gen.GenerateDouble(1260, 9010)),
			};
		}

	}

	[System.Serializable]
	public class UDTO_Electrical  : UDTO_SensorBase
	{
		public Voltage voltage;
		public Current current;
		public Resistance resistance;
		public Power wattage;
		public Capacitance capacitance;
		public Temperature temperature;

	}
}