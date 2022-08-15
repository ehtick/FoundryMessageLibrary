using System.Collections.Generic;

namespace IoBTMessage.Models
{

	[System.Serializable]
	public class UDTO_Camera : UDTO_Base
	{
		public Dictionary<string, object> attributes;
		public string name;
		public string active;
		public string codec;
		public string url;

#if !UNITY
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

		public override string getUniqueCode()
		{
			return $"{this.udtoTopic}{this.sourceGuid}{this.panID}{this.name}{this.codec}{this.url}";
		}
#endif
	}
}