using System;
using IoBTMessage.Units;

namespace IoBTMessage.Models
{
	

public class SPEC_HighResPosition
{
	public double xLoc { get; set; } = 0;
	public double yLoc { get; set; } = 0;
	public double zLoc { get; set; } = 0;

	public double xAng { get; set; } = 0;
	public double yAng { get; set; } = 0;
	public double zAng { get; set; } = 0;

	public static SPEC_HighResPosition RandomSpec()
	{
		var gen = new MockDataGenerator();
		return new SPEC_HighResPosition()
		{
			xLoc = gen.GenerateDouble(10, 90),
			yLoc = gen.GenerateDouble(10, 90),
			zLoc = gen.GenerateDouble(10, 90),
		};
	}
}

[System.Serializable]
	public class HighResPosition
	{
		public Length xLoc;
		public Length yLoc;
		public Length zLoc;

		public Angle xAng;
		public Angle yAng;
		public Angle zAng;

		public HighResPosition()
		{
			xLoc = new(0);
			yLoc = new(0);
			zLoc = new(0);

			xAng = new(0);
			yAng = new(0);
			zAng = new(0);
		}
		public HighResPosition(HighResPosition source)
		{
			copyFrom(source);
		}
		public HighResPosition(double xLoc, double yLoc, double zLoc, string units = "m")
		{
			this.xLoc = new(xLoc, units);
			this.yLoc = new(yLoc, units);
			this.zLoc = new(zLoc, units);
		}

		public FoVector3D LocAsVector3D()
		{
			return new FoVector3D(xLoc.Value(), yLoc.Value(), zLoc.Value());
		}

		public FoVector3D AngAsVector3D()
		{
			return new FoVector3D(xAng.Value(), yAng.Value(), zAng.Value());
		}

		public double distanceXZ()
		{
			return Math.Sqrt(this.xLoc.V * this.xLoc.V + this.zLoc.V * this.zLoc.V);
		}

		public double bearingXZ()
		{
			return Math.Atan2(this.xLoc.V, this.zLoc.V);
		}



		public HighResPosition copyFrom(HighResPosition pos)
		{
			this.xLoc = pos.xLoc.Copy();
			this.yLoc = pos.yLoc.Copy();
			this.zLoc = pos.zLoc.Copy();
			this.xAng = pos.xAng.Copy();
			this.yAng = pos.yAng.Copy();
			this.zAng = pos.zAng.Copy();
			return this;
		}
		public HighResPosition Loc(double xLoc, double yLoc, double zLoc, string units = "m")
		{
			this.xLoc = this.xLoc == null ? new(xLoc, units) : this.xLoc.Assign(xLoc, units);
			this.yLoc = this.yLoc == null ? new(yLoc, units) : this.yLoc.Assign(yLoc, units);
			this.zLoc = this.zLoc == null ? new(zLoc, units) : this.zLoc.Assign(zLoc, units);
			return this;
		}
		public HighResPosition Ang(double xAng, double yAng, double zAng, string units = "r")
		{
			this.xAng = this.xAng == null ? new(xAng, units) : this.xAng.Assign(xAng, units);
			this.yAng = this.yAng == null ? new(yAng, units) : this.yAng.Assign(yAng, units);
			this.zAng = this.zAng == null ? new(zAng, units) : this.zAng.Assign(zAng, units);
			return this;
		}

	}
}

