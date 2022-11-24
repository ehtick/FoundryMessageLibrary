namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_Document : DT_Title
	{
		public string status;
		public string filename;
		public string docType;
		public string url;
		public BoundingBox boundingbox;


#if !UNITY
		public DT_Document() : base()
		{
			status = "NotReferenced";
		}

		public void MarkAsNotFound()
		{
			status = "NotFound";
		}
		public void MarkAsLocalCashe()
		{
			status = "LocalCashe";
		}
		public void MarkAsBlobStorage()
		{
			status = "BlobStorage";
		}
		public void MarkAsExternalReference()
		{
			status = "ExternalReference";
		}
#endif
	}


}


