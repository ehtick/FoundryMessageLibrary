using System.Xml.Linq;

namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_Sensor : DT_Hero
	{
		public string serialNumber;
		public string partNumber;

#if !UNITY
		public DT_Sensor() : base()
		{

		}

		public string partName()
		{
			if ( string.IsNullOrEmpty(serialNumber))
				return partNumber;

			return $"{partNumber}@{serialNumber}";
		}

		public DT_Sensor ShallowCopy()
		{
			var result = (DT_Sensor)this.MemberwiseClone();
			return result;
		}
#endif
	}






}