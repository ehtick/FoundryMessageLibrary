namespace IoBTMessage.Models;

[System.Serializable]
public class HighResPosition
{
    public string units { get; set; } = "m";
    public double xLoc { get; set; }
    public double yLoc { get; set; }
    public double zLoc { get; set; }

    public double xAng { get; set; }
    public double yAng { get; set; }
    public double zAng { get; set; }

    public HighResPosition()
    {
    }

    public string compress(char d = ',')
    {
        // 7 Fields
        units = units == string.Empty ? "m" : units;
        return $"{units}{d}{xLoc}{d}{yLoc}{d}{zLoc}{d}{xAng}{d}{yAng}{d}{zAng}";
    }

    public int decompress(string[] data)
    {
        int counter = 0;
        units = data[counter++];
        xLoc = IoBTMath.toDouble(data[counter++]);
        yLoc = IoBTMath.toDouble(data[counter++]);
        zLoc = IoBTMath.toDouble(data[counter++]);
        xAng = IoBTMath.toDouble(data[counter++]);
        yAng = IoBTMath.toDouble(data[counter++]);
        zAng = IoBTMath.toDouble(data[counter++]);
        return counter;
    }

    public double distanceXZ()
    {
        return Math.Sqrt(this.xLoc * this.xLoc + this.zLoc * this.zLoc);
    }

    public double bearingXZ()
    {
        return Math.Atan2(this.xLoc, this.zLoc);
    }



    public HighResPosition copyFrom(HighResPosition pos)
    {
        this.units = pos.units;
        this.xLoc = pos.xLoc;
        this.yLoc = pos.yLoc;
        this.zLoc = pos.zLoc;
        this.xAng = pos.xAng;
        this.yAng = pos.yAng;
        this.zAng = pos.zAng;
        return this;
    }
}

