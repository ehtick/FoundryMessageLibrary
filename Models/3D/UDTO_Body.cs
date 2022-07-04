namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Body : UDTO_3D
{
    public string symbol { get; set; }
    public HighResPosition position { get; set; }
    public BoundingBox boundingBox { get; set; }

    public UDTO_Body() : base()
    {
    }

	public override UDTO_3D CopyFrom(UDTO_3D obj)
	{
		base.CopyFrom(obj);

		var body = obj as UDTO_Body;
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

	public UDTO_Body CreateBox(double width=1.0, double height = 1.0, double depth = 1.0, string units="m")
	{
		this.type = "Box";
		boundingBox = new BoundingBox()
		{
			units = units,
			width = width,
			height = height,
			depth = depth,
		};
		position = new HighResPosition();
		return this;
	}

	public UDTO_Body CreateCylinder(double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
	{
		this.type = "Cylinder";
		boundingBox = new BoundingBox()
		{
			units = units,
			width = width,
			height = height,
			depth = depth,
		};
		position = new HighResPosition();
		return this;
	}

	public UDTO_Body CreateSphere(double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
	{
		this.type = "Sphere";
		boundingBox = new BoundingBox()
		{
			units = units,
			width = width,
			height = height,
			depth = depth,
		};
		position = new HighResPosition();
		return this;
	}

	public UDTO_Body CreateGlb(string url, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
	{
		symbol = url;
		this.type = "Glb";
		boundingBox = new BoundingBox()
		{
			units = units,
			width = width,
			height = height,
			depth = depth,
		};
		position = new HighResPosition();
		return this;
	}

}

