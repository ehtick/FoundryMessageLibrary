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
		public Length width;
		public Length height;
		public Length depth;
		public Length pinX;
		public Length pinY;
		public Length pinZ;


		public BoundingBox()
		{
			width = new(0);
			height = new(0);
			depth = new(0);
			pinX = new(0);
			pinY = new(0);
			pinZ = new(0);
		}

		public BoundingBox(BoundingBox source)
		{
			copyFrom(source);
		}

		public BoundingBox(double width, double height, double depth, string units = "m")
		{
			this.width = new(width, units);
			this.height = new(height, units);
			this.depth = new(depth, units);
		}



		public BoundingBox copyFrom(BoundingBox pos)
		{
			this.width = pos.width.Copy();
			this.height = pos.height.Copy();
			this.depth = pos.depth.Copy();
			this.pinX = pos.pinX.Copy();
			this.pinY = pos.pinY.Copy();
			this.pinZ = pos.pinZ.Copy();
			return this;
		}

		public BoundingBox Box(double width, double height, double depth, string units="m")
		{
			this.width = new(width, units);
			this.height = new(height, units);
			this.depth = new(depth, units);
			return this;
		}
		public BoundingBox Pin(double pinX, double pinY, double pinZ, string units = "m")
		{
			this.pinX = new(pinX, units);
			this.pinY = new(pinY, units);
			this.pinZ = new(pinZ, units);
			return this;
		}
	}
}
