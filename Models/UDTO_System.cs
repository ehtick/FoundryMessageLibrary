
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


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

	public class SPEC_System : SPEC_Base
	{
		public double cpuUsage { get; set; }
		public double cpuSize { get; set; }
		public double memoryUsage { get; set; }
		public double memorySize { get; set; }
		public double diskUsage { get; set; }
		public double diskSize { get; set; }
	}

	[System.Serializable]
	public class UDTO_System : UDTO_Base
	{
		public double cpuUsage;
		public double cpuSize;
		public double memoryUsage;
		public double memorySize;
		public double diskUsage;
		public double diskSize;
	}
}