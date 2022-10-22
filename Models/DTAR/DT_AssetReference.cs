using System.Collections.Generic;

namespace IoBTMessage.Models
{
	public interface IDT_Reference 
	{
		//string targetGuid;
	}

	[System.Serializable]
	public class DT_AssetReference : DT_Title, IDT_Reference
	{
		public string assetGuid;
		public string targetGuid;
		public DT_Document document;
		public HighResPosition position;

#if !UNITY
		public DT_AssetReference() : base()
		{
		}

		public DT_AssetReference ShallowCopy()
		{
			var result = (DT_AssetReference)this.MemberwiseClone();
			result.assetGuid = document?.guid ?? assetGuid;
			result.document = null;
			return result;
		}
#endif
	}
}