using System.Xml.Linq;

namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_Component : DT_Hero
	{
		public string serialNumber;
		public string partNumber;
		public string revision;
		public string nha;
		public string assemblyNumber;
		public string configuration;

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


	[System.Serializable]
	public class DT_ComponentReference : DT_Base
	{
		public string partNumber;
		public string componentGuid;
		public DT_Component component;

#if !UNITY
		public DT_ComponentReference() : base()
		{
		}
		public DT_ComponentReference ShallowCopy()
		{
			var result = (DT_ComponentReference)this.MemberwiseClone();
			result.componentGuid = component?.guid ?? componentGuid;
			result.partNumber = component?.partNumber ?? partNumber;
			result.component = null;
			return result;
		}
#endif
	}


}