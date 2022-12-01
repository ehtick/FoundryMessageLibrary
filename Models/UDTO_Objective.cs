namespace IoBTMessage.Models
{

	public partial class SEPC_Objective : SPEC_UniqueLocation
	{
		public string name { get; set; }
		public string type { get; set; }
		public string symbol { get; set; }
		public string note { get; set; }
	}

	[System.Serializable]
	public partial class UDTO_Objective : UniqueLocation
	{
		public string name;
		public string type;
		public string symbol;
		public string note;

#if !UNITY
		public override string compress(char d = ',')
		{
			return $"{base.compress(d)}{d}{name}{d}{type}{d}{symbol}{d}{note}";
		}

		public override int decompress(string[] data)
		{
			var counter = base.decompress(data);
			name = data[counter++];
			type = data[counter++];
			symbol = data[counter++];
			note = data[counter++];
			return counter;
		}
#endif
	}
}

