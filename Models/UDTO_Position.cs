namespace IoBTMessage.Models
{

	public class SPEC_Position : SPEC_Location
	{
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