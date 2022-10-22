namespace IoBTMessage.Models
{
	[System.Serializable]
	public class DT_ComponentReference : DT_Title, IDT_Reference
	{
		public string partNumber;
		public string targetGuid;
		public DT_Component component;

#if !UNITY
		public DT_ComponentReference() : base()
		{
		}
		public DT_ComponentReference ShallowCopy()
		{
			var result = (DT_ComponentReference)this.MemberwiseClone();
			result.targetGuid = component?.guid ?? targetGuid;
			result.partNumber = component?.partNumber ?? partNumber;
			result.component = null;
			return result;
		}
#endif
	}
}