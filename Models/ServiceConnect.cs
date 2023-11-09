
namespace IoBTMessage.Models
{

	[System.Serializable]
	public class ServiceConnect
	{
		public string url { get; set; }
		public string servicename { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public string database { get; set; }
		public bool isconnected { get; set; } = false;  
	}
}