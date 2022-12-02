using System.Collections.Generic;

namespace IoBTMessage.Models
{

	public class SPEC_Camera : SPEC_Base
	{
		public ControlParameters metadata { get; set; }
		public string name { get; set; }
		public string active { get; set; }
		public string codec { get; set; }
		public string url { get; set; }
	}
	[System.Serializable]
	public class UDTO_Camera : UDTO_Base
	{
		public ControlParameters metadata;
		public string name;
		public string active;
		public string codec;
		public string url;


		public UDTO_Camera() : base()
		{
		}

		public override string compress(char d = ',')
		{
			return $"{base.compress(d)}{d}{this.name}{d}{this.active}{d}{this.codec}{d}{this.url}";
		}

		public override int decompress(string[] data)
		{
			var counter = base.decompress(data);
			this.name = data[counter++];
			this.active = data[counter++];
			this.codec = data[counter++];
			this.url = data[counter++];
			return counter;
		}

	}
}