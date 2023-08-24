using FoundryRulesAndUnits.Models;

namespace IoBTMessage.Models
{


	[System.Serializable]
	public class UDTO_Body : UDTO_3D
	{
		public string symbol;
		public HighResPosition position;
		public BoundingBox boundingBox;


		public UDTO_Body() : base()
		{
		}

		public override UDTO_3D CopyFrom(UDTO_3D obj)
		{
			base.CopyFrom(obj);

			var body = obj as UDTO_Body;
			this.symbol = body!.symbol;

			if (this.position == null)
			{
				this.position = body.position;
			}
			else if (body.position != null)
			{
				this.position.copyFrom(body.position);
			}

			if (this.boundingBox == null)
			{
				this.boundingBox = body.boundingBox;
			}
			else if (body.boundingBox != null)
			{
				this.boundingBox.copyFrom(body.boundingBox);
			}
			return this;
		}

		public UDTO_Body EstablishLoc(double x = 0.0, double y = 0.0, double z = 0.0, string units = "m")
		{
			position ??= new HighResPosition();

			position.Loc(x, y, z, units);
			return this;
		}
		public UDTO_Body EstablishAng(double x = 0.0, double y = 0.0, double z = 0.0, string units = "r")
		{
			position ??= new HighResPosition();

			position.Ang(x, y, z, units);
			return this;
		}
		public UDTO_Body EstablishBox(double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			boundingBox ??= new BoundingBox();

			boundingBox.Box(width, height, depth, units);
			return this;
		}

		public UDTO_Body EstablishPiv(double px = 0.0, double py = 0.0, double pz = 0.0, string units = "m")
		{
			boundingBox ??= new BoundingBox();

			boundingBox.Pin(px, py, pz, units);
			return this;
		}

		public UDTO_Body CreateBox(string name, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			this.type = "Box";
			this.name = name;
			return EstablishBox(width, height, depth, units);
		}

		public UDTO_Body CreateCylinder(string name, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			this.type = "Cylinder";
			this.name = name;
			return EstablishBox(width, height, depth, units);
		}

		public UDTO_Body CreateSphere(string name, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			this.type = "Sphere";
			this.name = name;
			return EstablishBox(width, height, depth, units);
		}

		public UDTO_Body CreateGlb(string url, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			symbol = url;
			this.type = "Glb";
			return EstablishBox(width, height, depth, units);
		}
	}

}