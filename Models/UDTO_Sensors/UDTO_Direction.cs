using FoundryRulesAndUnits.Units;

namespace IoBTMessage.Models
{
	public class SPEC_Direction : SPEC_SensorBase
	{
		public Speed speed { get; set; }
		public Heading heading { get; set; }
	}

	public class UDTO_Direction : UDTO_SensorBase
	{
		public Speed speed;
		public Heading heading;

	}
}

