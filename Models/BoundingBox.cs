namespace IoBTMessage.Models;

[System.Serializable]
public class BoundingBox
{
    public string units { get; set; } = "m";
    public double width { get; set; }
    public double height { get; set; }
    public double depth { get; set; }
    public double pinX { get; set; }
    public double pinY { get; set; }
    public double pinZ { get; set; }

    public BoundingBox()
    {
    }

    public string compress(char d = ',')
    {
        // 7 Fields
        units = units == string.Empty ? "m" : units;
        return $"{units}{d}{width}{d}{height}{d}{depth}{d}{pinX}{d}{pinY}{d}{pinZ}";
    }

    public int decompress(string[] data)
    {
        var counter = 0;
        units = data[counter++];
        width = IoBTMath.toDouble(data[counter++]);
        height = IoBTMath.toDouble(data[counter++]);
        depth = IoBTMath.toDouble(data[counter++]);
        pinX = IoBTMath.toDouble(data[counter++]);
        pinY = IoBTMath.toDouble(data[counter++]);
        pinZ = IoBTMath.toDouble(data[counter++]);
        return counter;
    }

    public BoundingBox copyFrom(BoundingBox pos)
    {
        this.units = pos.units;
        this.width = pos.width;
        this.height = pos.height;
        this.depth = pos.depth;
        this.pinX = pos.pinX;
        this.pinY = pos.pinY;
        this.pinZ = pos.pinZ;
        return this;
    }
}

