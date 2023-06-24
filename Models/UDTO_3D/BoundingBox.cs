using IoBTMessage.Units;

namespace IoBTMessage.Models
{
	public class SPEC_BoundingBox
	{
		public Length width{ get; set; }
		public Length height { get; set; }
		public Length depth { get; set; }
		public Length pinX { get; set; }
		public Length pinY { get; set; }
		public Length pinZ { get; set; }

		public static SPEC_BoundingBox RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_BoundingBox()
			{
				width = new(gen.GenerateDouble(10, 90)),
				height = new(gen.GenerateDouble(10, 90)),
				depth = new(gen.GenerateDouble(10, 90)),
			};
		}
	}
	[System.Serializable]
	public class BoundingBox
	{
		public Length width = new(10);
		public Length height  = new(20);
		public Length depth  = new(30);

		public Length pinX  = new(0);
		public Length pinY  = new(0);
		public Length pinZ  = new(0);


		public BoundingBox()
		{
			//width = new(0);
			//height = new(0);
			//depth = new(0);
			//pinX = new(0);
			//pinY = new(0);
			//pinZ = new(0);
		}

		public BoundingBox(BoundingBox source) : this()
		{
			copyFrom(source);
		}

		public BoundingBox(double width, double height, double depth, string units = "m") : this()
		{
			this.Box(width ,height, depth, units);
		}



		public BoundingBox copyFrom(BoundingBox pos)
		{
			this.width.Assign(pos.width);
			this.height.Assign(pos.height);
			this.depth.Assign(pos.depth);
			this.pinX.Assign(pos.pinX);
			this.pinY.Assign(pos.pinY);
			this.pinZ.Assign(pos.pinZ);
			return this;
		}

		public BoundingBox Box(double width, double height, double depth, string units="m")
		{
			this.width = this.width == null ? new(width, units) : this.width.Assign(width, units);
			this.height = this.height == null ? new(height, units) : this.height.Assign(height, units);
			this.depth = this.depth == null ? new(depth, units) : this.depth.Assign(depth, units);
			return this;
		}
		public BoundingBox Pin(double pinX, double pinY, double pinZ, string units = "m")
		{
			this.pinX = this.pinX == null ? new(pinX, units) : this.pinX.Assign(pinX, units);
			this.pinY = this.pinY == null ? new(pinY, units) : this.pinY.Assign(pinY, units);
			this.pinZ = this.pinZ == null ? new(pinZ, units) : this.pinZ.Assign(pinZ, units);
			return this;
		}
	}
}
