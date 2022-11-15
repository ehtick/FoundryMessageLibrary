namespace IoBTMessage.Models
{
	[System.Serializable]
	public class DT_ComponentReference : DT_Title, IDT_Reference
	{
		public DT_Part part;
		public DT_Component component;

#if !UNITY
		public DT_ComponentReference() : base()
		{
		}
		public DT_Part MarkAsTemplate()
		{
			part ??= new DT_Part();
			part.serialNumber = "TBD";
			return part;
		}
		public DT_ComponentReference ShallowCopy()
		{
			var result = (DT_ComponentReference)this.MemberwiseClone();
			if ( part != null )
				result.part = (DT_Part)part.ShallowCopy();

			result.component = null;
			return result;
		}
#endif
	}
}