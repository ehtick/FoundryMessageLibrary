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

	public override string compress(char d = ',')
    {
        // 23 Fields
        // base (0, 1, 2, 3) uniqueGuid (4) bodyName (5) bodyType (6) symbol (7) platformName (8) position (9, 10, 11, 12, 13, 14, 15) 
        return $"{base.compress(d)}{d}{targetGuid}{d}{text}{d}{position?.compress(d)}";
    }

    public override int decompress(string[] inputData)
    {
        var counter = base.decompress(inputData);

        targetGuid = inputData[counter++];
        text = inputData[counter++];


        if (inputData[counter] != String.Empty)
        {
            position = new HighResPosition();
            ArraySegment<string> positionSeg = new ArraySegment<string>(inputData, counter, inputData.Length - counter);
            counter += position.decompress(positionSeg.ToArray());
        }
        else
        {
            counter++;
        }
 
        return counter;
    }
}

