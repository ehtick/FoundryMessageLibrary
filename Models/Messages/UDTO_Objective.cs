namespace IoBTMessage.Models
{

	public partial class SPEC_Objective : SPEC_UniqueLocation
	{
		public string name { get; set; }
		public string type { get; set; }
		public string symbol { get; set; }
		public string note { get; set; }
	}

	[System.Serializable]
	public partial class UDTO_Objective : UniqueLocation
	{
		public string name;
		public string type;
		public string symbol;
		public string note;

	}
}

