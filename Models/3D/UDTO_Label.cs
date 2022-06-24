namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Label : UDTO_3D
{
    public string text { get; set; }
    public string targetGuid { get; set; }
    public HighResPosition position { get; set; }


    public UDTO_Label() : base()
    {
    }

	public override UDTO_3D CopyFrom(UDTO_3D obj)
	{
		base.CopyFrom(obj);

		var label = obj as UDTO_Label;
		if (this.position == null)
		{
			this.position = label.position;
		}
		else if (label.position != null)
		{
			this.position.copyFrom(label.position);
		}

		return this;
	}

	public UDTO_Label CreateTextAt(string text, double xLoc = 0.0, double yLoc = 0.0, double zLoc = 0.0, string units="m")
	{
		this.text = text.Trim();
		this.type = "Label";
		position = new HighResPosition()
		{
			units = units,
			xLoc = xLoc,
			yLoc = yLoc,
			zLoc = zLoc
		};
		return this;
	}

}

