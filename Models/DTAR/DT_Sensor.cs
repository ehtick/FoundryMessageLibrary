using System.Xml.Linq;

namespace IoBTMessage.Models
{

	public class DO_Sensor : DO_AssemblyItem
	{
		public string topic { get; set; }
		public string sourceGuid { get; set; }
	}

	public class DT_Sensor : DT_AssemblyItem
	{
		public string topic;
		public string sourceGuid;
		public DT_Sensor() : base()
		{
		}

		public DT_Sensor ShallowCopy()
		{
			var result = (DT_Sensor)this.MemberwiseClone();
			if (part != null)
				result.part = (DT_Part)part.ShallowCopy();
			result.heroImage = this.heroImage;

			return result;
		}
	}

}