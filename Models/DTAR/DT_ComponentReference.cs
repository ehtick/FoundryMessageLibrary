namespace IoBTMessage.Models
{
	[System.Serializable]
	public class DT_ComponentReference : DT_Title
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