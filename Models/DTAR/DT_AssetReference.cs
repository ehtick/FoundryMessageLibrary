using System.Collections.Generic;

namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_AssetReference : DT_Base
	{
		public string assetGUID;
		public string docGuid;
		public DT_ControlNumbers lookups = new DT_ControlNumbers();
		public DT_Document document;

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