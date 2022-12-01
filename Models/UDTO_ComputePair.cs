namespace IoBTMessage.Models
{

	public class SPEC_ComputePair : SPEC_Base
	{
		public string type { get; set; }
		public string name { get; set; }
		public string active { get; set; }
		public string version { get; set; }
		public string info { get; set; }
		public string container { get; set; }
		public string sourceURL { get; set; }
		public string targetURL { get; set; }
		public string lastEvent { get; set; }
		public string lastError { get; set; }
		public string purpose { get; set; }
	}
	
	[System.Serializable]
	public class UDTO_ComputePair : UDTO_Base
	{
		public string type;
		public string name;
		public string active;
		public string version;
		public string info;
		public string container;
		public string sourceURL;
		public string targetURL;
		public string lastEvent;
		public string lastError;
		public string purpose;


		public UDTO_ComputePair() : base()
		{
		}

		public override string compress(char d = ',')
		{
			return $"{base.compress(d)}{d}{this.name}{d}{this.type}{d}{this.active}{d}{this.info}{d}{this.container}{d}{this.sourceURL}";
		}

		public override int decompress(string[] data)
		{
			var counter = base.decompress(data);
			this.name = data[counter++];
			this.type = data[counter++];
			this.active = data[counter++];
			this.info = data[counter++];
			this.container = data[counter++];
			this.sourceURL = data[counter++];
			return counter;
		}


	}
}
