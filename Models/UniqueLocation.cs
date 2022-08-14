namespace IoBTMessage.Models
{
	public class UniqueLocation : Location
	{
		public string uniqueGuid;

#if !UNITY
		public override string getUniqueCode()
		{
			return $"{this.uniqueGuid}";
		}

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
#endif
	}
}

