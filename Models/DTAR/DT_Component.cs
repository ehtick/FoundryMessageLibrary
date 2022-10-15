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
			return $"{partName()}@{serialNumber}";
		}
		public string partName()
		{
			return $"{partNumber}-{revision}";
		}
#endif
	}


	[System.Serializable]
	public class DT_ComponentReference : DT_Base
	{
		public string componentGuid;
		public DT_Component component;

#if !UNITY
		public DT_ComponentReference() : base()
		{
		}
#endif
	}


}