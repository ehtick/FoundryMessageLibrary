namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_Document : DT_Title
	{
		public string docType;
		public string filename;
		public string url;
		public BoundingBox boundingbox;


#if !UNITY
		public DT_Document() : base()
		{
		}
#endif
	}


}


