using System.Collections.Generic;

namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_AssetReference : DT_Title
	{
		public string assetGUID;
		public string docGuid;
		public DT_Document document;
		public HighResPosition position;

#if !UNITY
		public DT_AssetReference() : base()
		{
		}

		public DT_AssetReference ShallowCopy()
		{
			var result = (DT_AssetReference)this.MemberwiseClone();
			result.assetGUID = document?.guid ?? assetGUID;
			result.document = null;
			return result;
		}
#endif
	}
}