using System.Collections.Generic;

namespace IoBTMessage.Models
{

	public class SPEC_Image : SPEC_SensorBase
	{
		public int width { get; set; }
		public int height { get; set; }
		public string url { get; set; }
	}
	[System.Serializable]
	public class UDTO_Image : UDTO_SensorBase
	{
		public int width;
		public int height;
		public string url;


		public UDTO_Image() : base()
		{
		}

	}
}