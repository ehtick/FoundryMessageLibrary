
namespace IoBTMessage.Models
{
	[System.Serializable]
	public class UDTO_Generic : UDTO_Base
	{
		public string type;
		public string routing;
		public object entity;
	}
}