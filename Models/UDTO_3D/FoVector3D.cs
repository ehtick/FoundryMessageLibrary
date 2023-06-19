
using System;

namespace IoBTMessage.Models
{
	public class FoVector3D
	{
		public double X = 0;
		public double Y = 0;
		public double Z = 0;

		public FoVector3D()
		{
		}
		public FoVector3D(double x, double y, double z)
		{
			Set(x, y, z);
		}



		public double DistanceXZ()
		{
			return Math.Sqrt(this.X * this.X + this.Z * this.Z);
		}

		public double BearingXZ()
		{
			return Math.Atan2(this.X, this.Z);
		}


		public FoVector3D CopyFrom(FoVector3D pos)
		{
			this.X = pos.X;
			this.Y = pos.Y;
			this.Z = pos.Z;

			return this;
		}
		public FoVector3D Set(double x, double y, double z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			return this;
		}
	}
}