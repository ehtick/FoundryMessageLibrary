namespace IoBTMessage.Models
{
	[System.Serializable]
	public class UDTO_ChatMessage : UDTO_Base
	{
		public string toUser;
		public string fromUser;
		public string message;

#if !UNITY
		public UDTO_ChatMessage() : base()
		{
		}
		public override string compress(char d = ',')
		{
			return $"{base.compress(d)}{d}{toUser}{d}{fromUser}{d}{message}";
		}

		public override int decompress(string[] data)
		{
			var count = base.decompress(data);
			toUser = data[count++];
			fromUser = data[count++];
			message = data[count++];
			return count;
		}
#endif
	}
}

