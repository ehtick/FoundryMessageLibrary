namespace IoBTMessage.Models
{

	public partial class SPEC_Observation : SPEC_UniqueLocation
	{
		public string target { get; set; }
		public double range{ get; set; }
	}

	[System.Serializable]
	public partial class UDTO_Observation : UniqueLocation
	{
		public string target;
		public double range;


		public override string compress(char d = ',')
		{
			return $"{base.compress(d)}{d}{target}{d}{range}";
		}

		public override int decompress(string[] data)
		{
			var counter = base.decompress(data);
			target = data[counter++];
			range = IoBTMath.toDouble(data[counter++]);
			return counter;
		}

	}
}

