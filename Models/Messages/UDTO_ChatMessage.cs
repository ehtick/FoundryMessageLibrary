namespace IoBTMessage.Models
{
	public class SPEC_ChatMessage : SPEC_Base
	{
		public string toUser { get; set; }
		public string fromUser { get; set; }
		public string message { get; set; }
	}
	
	[System.Serializable]
	public class UDTO_ChatMessage : UDTO_Base
	{
		public string toUser;
		public string fromUser;
		public string message;


		public UDTO_ChatMessage() : base()
		{
		}
	}
}

