namespace IoBTMessage.Models
{

	public class UDTO_Direction : UDTO_Base
	{
		public double speed;
		public double heading;

#if !UNITY
		public override string compress(char d = ',')
		{
			return $"{base.compress(d)}{d}{speed}{d}{heading}";
		}

		public override int decompress(string[] data)
		{
			var counter = base.decompress(data);
			speed = IoBTMath.toDouble(data[counter++]);
			heading = IoBTMath.toDouble(data[counter++]);
			return counter;
		}

		public override string getUniqueCode()
		{
			return $"{udtoTopic}{sourceGuid}{panID}";
		}
#endif
	}
}

