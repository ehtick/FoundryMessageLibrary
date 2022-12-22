using System;

namespace IoBTMessage.Models
{

	public class SPEC_Position : SPEC_Location
	{
		public static SPEC_Position RandomSpec()
		{
			 //var rand = new Random();
			return new SPEC_Position()
			{
				// lat = rand.NextDouble(-140,-144),
				// lng = rand.NextDouble(34,38),
				// alt = rand.NextDouble(10,100),
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