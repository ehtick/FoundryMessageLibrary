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

    public override string compress(char d = ',')
    {
        // 23 Fields
        // base (0, 1, 2, 3) uniqueGuid (4) bodyName (5) bodyType (6) symbol (7) platformName (8) position (9, 10, 11, 12, 13, 14, 15) boundingBox (16, 17, 18, 19, 20, 21, 22) 
        return $"{base.compress(d)}{d}{symbol}{d}{position?.compress(d)}{d}{boundingBox?.compress(d)}";
    }

    public override int decompress(string[] inputData)
    {
        var counter = base.decompress(inputData);
        symbol = inputData[counter++];
 
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
        if (inputData[counter] != String.Empty)
        {
            boundingBox = new BoundingBox();
            ArraySegment<string> boundingBoxSeg = new ArraySegment<string>(inputData, counter, inputData.Length - counter);
            counter += boundingBox.decompress(boundingBoxSeg.ToArray());
        }
        else
        {
            counter++;
        }
        return counter;
    }
}

