using System.Xml.Linq;

namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_Component : DT_Hero
	{
		public string referenceDesignation;
		public string partNumber;
		public string revision;
		public string serialNumber;
		public string nha;
		//public string assemblyNumber;
		//public string configuration;

#if !UNITY
		public DT_Component() : base()
		{

		}
		public string serialName()
		{
			if ( string.IsNullOrEmpty(serialNumber))
				return partName();

			return $"{partName()}@{serialNumber}";
		}
		public string partName()
		{
			if ( string.IsNullOrEmpty(revision))
				return partNumber;

			return $"{partNumber}-{revision}";
		}

		public DT_Component ShallowCopy()
		{
			var result = (DT_Component)this.MemberwiseClone();
			return result;
		}
#endif
	}






}