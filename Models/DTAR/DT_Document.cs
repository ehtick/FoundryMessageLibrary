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
		}
		public bool IsReadyToUse()
		{
			if ( status == "LocalCashe" ) return true;
			return false;
		}
		public string MarkAsNotReferences()
		{
			status = "NotReferenced";
			return status;
		}
		public string MarkAsNotFound()
		{
			status = "NotFound";
			return status;
		}
		public string MarkAsLocalCashe()
		{
			status = "LocalCashe";
			return status;
		}
		public string MarkAsBlobStorage()
		{
			status = "BlobStorage";
			return status;
		}
		public string MarkAsExternalReference()
		{
			status = "ExternalReference";
			return status;
		}
#endif
	}


}


