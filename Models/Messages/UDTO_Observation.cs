namespace IoBTMessage.Models
{

	public partial class SPEC_Observation : SPEC_UniqueLocation
	{
		public string target { get; set; }
		public double range{ get; set; }
	}

	[System.Serializable]
	public partial class UDTO_Observation : UniqueLocation
	{
		public string target;
		public double range;

	}
}

