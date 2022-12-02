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
		public string documentGuid;
		public string heroGuid;
		public DT_Document document;
		public HighResPosition position;


		public DT_AssetReference() : base()
		{
		}

		public DT_AssetReference AttachDocument(DT_Document doc) 
		{
			document = doc;
			documentGuid = doc.guid;
			return this;
		}

		public DT_AssetReference ClearDocument() 
		{
			documentGuid = document?.guid;
			document = null;
			return this;
		}

		public DT_AssetReference ShallowCopy()
		{
			var result = (DT_AssetReference)this.MemberwiseClone();
			result.ClearDocument();
			return result;
		}

	}
}