using System.Xml.Linq;

namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_Sensor : DT_Component
	{

#if !UNITY
		public DT_Sensor() : base()
		{

		}
#endif
	}

}