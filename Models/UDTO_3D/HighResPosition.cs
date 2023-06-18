using System;
using IoBTMessage.Units;

namespace IoBTMessage.Models
{
	

public class SPEC_HighResPosition
{
	public string units { get; set; } = "m";
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
		public string units = "m";
		public Length xLoc = new(0);
		public Length yLoc = new(0);
		public Length zLoc = new(0);

		public Angle xAng = new(0);
		public Angle yAng = new(0);
		public Angle zAng = new(0);

		public HighResPosition()
		{
		}
		public HighResPosition(double xLoc, double yLoc, double zLoc, string units = "m")
		{
			this.units = units;
			this.xLoc = new(xLoc, units);
			this.yLoc = new(yLoc, units);
			this.zLoc = new(zLoc, units);
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
			this.units = pos.units;
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
			this.units = units;
			this.xLoc = new(xLoc, units);
			this.yLoc = new(yLoc, units);
			this.zLoc = new(zLoc, units);
			return this;
		}
		public HighResPosition Ang(double xAng, double yAng, double zAng, string units = "m")
		{
			this.units = units;
			this.xAng = new(xAng, units);
			this.yAng = new(yAng, units);
			this.zAng = new(zAng, units);
			return this;
		}

	}
}

