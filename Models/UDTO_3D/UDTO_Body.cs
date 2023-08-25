using FoundryRulesAndUnits.Models;

namespace IoBTMessage.Models
{


	[System.Serializable]
	public class UDTO_Body : UDTO_3D
	{
		public string symbol;
		public UDTO_HighResPosition position;
		public UDTO_BoundingBox boundingBox;


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
				this.position.copyOther(body.position);
			}

			if (this.boundingBox == null)
			{
				this.boundingBox = body.boundingBox;
			}
			else if (body.boundingBox != null)
			{
				this.boundingBox.copyOther(body.boundingBox);
			}
			return this;
		}

		public UDTO_Body EstablishLoc(double x = 0.0, double y = 0.0, double z = 0.0)
		{
			position ??= new UDTO_HighResPosition();
			position.Loc(x, y, z);
			return this;
		}
		public UDTO_Body EstablishAng(double x = 0.0, double y = 0.0, double z = 0.0)
		{
			position ??= new UDTO_HighResPosition();
			position.Ang(x, y, z);
			return this;
		}
		public UDTO_Body EstablishBox(double width = 1.0, double height = 1.0, double depth = 1.0)
		{
			boundingBox ??= new UDTO_BoundingBox();
			boundingBox.Box(width, height, depth);
			return this;
		}

		public UDTO_Body EstablishPiv(double px = 0.0, double py = 0.0, double pz = 0.0)
		{
			boundingBox ??= new UDTO_BoundingBox();

			boundingBox.Pin(px, py, pz);
			return this;
		}

		public UDTO_Body CreateBox(string name, double width = 1.0, double height = 1.0, double depth = 1.0)
		{
			this.type = "Box";
			this.name = name;
			return EstablishBox(width, height, depth);
		}

		public UDTO_Body CreateCylinder(string name, double width = 1.0, double height = 1.0, double depth = 1.0)
		{
			this.type = "Cylinder";
			this.name = name;
			return EstablishBox(width, height, depth);
		}

		public UDTO_Body CreateSphere(string name, double width = 1.0, double height = 1.0, double depth = 1.0)
		{
			this.type = "Sphere";
			this.name = name;
			return EstablishBox(width, height, depth);
		}

		public UDTO_Body CreateGlb(string url, double width = 1.0, double height = 1.0, double depth = 1.0)
		{
			symbol = url;
			this.type = "Glb";
			return EstablishBox(width, height, depth);
		}
	}

}