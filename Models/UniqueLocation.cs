namespace IoBTMessage.Models
{
	public class SPEC_UniqueLocation : SPEC_Location
	{
		public string uniqueGuid { get; set; }
	}

	public class UniqueLocation : Location
	{
		public string uniqueGuid;



		public override string compress(char d = ',')
		{
			return $"{base.compress(d)}{d}{this.uniqueGuid}";
		}

		public override int decompress(string[] data)
		{
			var counter = base.decompress(data);
			this.uniqueGuid = data[counter++];
			return counter;
		}

	}
}

