using System.Xml.Linq;

namespace IoBTMessage.Models
{

	public class DO_Sensor : DO_Component
	{
		public string topic { get; set; }
		public string sourceGuid { get; set; }
	}

	public class DT_Sensor : DT_Component
	{
		public string topic;
		public string sourceGuid;
		public DT_Sensor() : base()
		{
		}
	}

}