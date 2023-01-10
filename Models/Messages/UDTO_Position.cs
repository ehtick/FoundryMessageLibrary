using System;

namespace IoBTMessage.Models
{

	public class SPEC_Position : SPEC_Location
	{
		public new double lat { get; set; }
		public new double lng { get; set; }
		public new double alt { get; set; }

		public static SPEC_Position RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_Position()
			{
				lat = gen.DoubleBetween(-140,-144),
				lng = gen.DoubleBetween(34,38),
				alt = gen.DoubleBetween(10,100),
			};
		}
	}

	[System.Serializable]
	public class UDTO_Position : Location
	{

		public UDTO_Position() : base()
		{
		}
		public UDTO_Position(Location loc) : base(loc)
		{
		}
	}

}