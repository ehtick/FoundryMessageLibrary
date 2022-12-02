
namespace IoBTMessage.Models
{
	
	public class SPEC_Generic : SPEC_Base
	{
		public string type { get; set; }
		public string routing { get; set; }
		public object entity { get; set; }
	}

	[System.Serializable]
	public class UDTO_Generic : UDTO_Base
	{
		public string type;
		public string routing;
		public object entity;
	}
}