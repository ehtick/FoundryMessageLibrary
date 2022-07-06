namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Body : UDTO_3D
{
	public string symbol;
	public HighResPosition position;
	public BoundingBox boundingBox;

#if !UNITY
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

	public UDTO_Body CreateBox(string name, double width=1.0, double height = 1.0, double depth = 1.0, string units="m")
	{
		this.type = "Box";
		this.name = name;
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

	public UDTO_Body CreateCylinder(string name, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
	{
		this.type = "Cylinder";
		this.name = name;
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

	public UDTO_Body CreateSphere(string name, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
	{
		this.type = "Sphere";
		this.name = name;
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
#endif
}

