﻿namespace DTARServer.Models
{

	[System.Serializable]
	public class DT_Document : DT_Title
	{
		public string docType;
		public string filename;
		public string url;

#if !UNITY
		public DT_Document() : base()
		{
		}
#endif
	}


	public class DT_Image : DT_Document
	{
	}

}


