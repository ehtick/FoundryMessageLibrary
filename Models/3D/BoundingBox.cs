namespace IoBTMessage.Models
{
	[System.Serializable]
	public class BoundingBox
	{
		public string units = "m";
		public double width;
		public double height;
		public double depth;
		public double pinX;
		public double pinY;
		public double pinZ;

#if !UNITY
		public BoundingBox()
		{
		}

		public string compress(char d = ',')
		{
			// 7 Fields
			units = units == string.Empty ? "m" : units;
			return $"{units}{d}{width}{d}{height}{d}{depth}{d}{pinX}{d}{pinY}{d}{pinZ}";
		}

		public int decompress(string[] data)
		{
			var counter = 0;
			units = data[counter++];
			width = IoBTMath.toDouble(data[counter++]);
			height = IoBTMath.toDouble(data[counter++]);
			depth = IoBTMath.toDouble(data[counter++]);
			pinX = IoBTMath.toDouble(data[counter++]);
			pinY = IoBTMath.toDouble(data[counter++]);
			pinZ = IoBTMath.toDouble(data[counter++]);
			return counter;
		}

		public BoundingBox copyFrom(BoundingBox pos)
		{
			this.units = pos.units;
			this.width = pos.width;
			this.height = pos.height;
			this.depth = pos.depth;
			this.pinX = pos.pinX;
			this.pinY = pos.pinY;
			this.pinZ = pos.pinZ;
			return this;
		}

		public BoundingBox Box(double width, double height, double depth, string units="m")
		{
			this.units = units;
			this.width = width;
			this.height = height;
			this.depth = depth;
			return this;
		}
		public BoundingBox Pin(double pinX, double pinY, double pinZ, string units = "m")
		{
			this.units = units;
			this.pinX = pinX;
			this.pinY = pinY;
			this.pinZ = pinZ;
			return this;
		}
#endif
	}
}
