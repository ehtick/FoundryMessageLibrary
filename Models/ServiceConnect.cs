
namespace IoBTMessage.Models
{

	[System.Serializable]
	public class ServiceConnect
	{
		public string url;  
		public string username; 
		public string password;  
		public string database;  
		public bool isconnected = false;  
	}
}