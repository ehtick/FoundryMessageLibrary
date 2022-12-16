using System;
namespace IoBTMessage.Models
{


	public class SPEC_HighResVector
	{
		public string units { get; set; } = "m";
		public double X { get; set; } = 0;
		public double Y { get; set; } = 0;
		public double Z { get; set; } = 0;
	}

	[System.Serializable]
	public class HighResVector
	{
		public string units = "m";
		public double X = 0;
		public double Y = 0;
		public double Z = 0;

		public HighResVector()
		{
		}

		public string compress(char d = ',')
		{
			// 7 Fields
			units = units == string.Empty ? "m" : units;
			return $"{units}{d}{X}{d}{Y}{d}{Z}{d}";
		}

		public int decompress(string[] data)
		{
			int counter = 0;
			units = data[counter++];
			X = IoBTMath.toDouble(data[counter++]);
			Y = IoBTMath.toDouble(data[counter++]);
			Z = IoBTMath.toDouble(data[counter++]);
			return counter;
		}

		public double distanceXZ()
		{
			return Math.Sqrt(this.X * this.X + this.Z * this.Z);
		}

		public double bearingXZ()
		{
			return Math.Atan2(this.X, this.Z);
		}



		public HighResVector copyFrom(HighResVector pos)
		{
			this.units = pos.units;
			this.X = pos.X;
			this.Y = pos.Y;
			this.Z = pos.Z;

			return this;
		}
		public HighResVector Loc(double xLoc, double yLoc, double zLoc, string units = "m")
		{
			this.units = units;
			this.X = xLoc;
			this.Y = yLoc;
			this.Z = zLoc;
			return this;
		}

	}
}

