using System;
using System.Collections.Generic;
using System.Linq;


namespace IoBTMessage.Models;


public interface ILocation
{
    public double lat { get; set; }
    public double lng { get; set; }
    public double alt { get; set; }
}


public partial class Location : UDTO_Base, ILocation
{
    public Location():base()
    {
    }

    public Location(Location obj):base()
    {
        lat = obj.lat;
        lng = obj.lng;
        alt = obj.alt;
    }

    public double lat { get; set; }
    public double lng { get; set; }
    public double alt { get; set; }


    public override string compress(char d = ',')
    {
        return $"{base.compress(d)}{d}{lat}{d}{lng}{d}{alt}";
    }

    public override int decompress(string[] data)
    {
        var counter = base.decompress(data);
        lat = IoBTMath.toDouble(data[counter++]);
        lng = IoBTMath.toDouble(data[counter++]);
        alt = IoBTMath.toDouble(data[counter++]);
        return counter;
    }
    public Location SetLocationTo(Location loc)
    {
        this.lat = loc.lat;
        this.lng = loc.lng;
        this.alt = loc.alt;
        return this;
    }

    // Converts numeric degrees to radians
    public double toRad(double ang)
    {
        return ang * Math.PI / 180;
    }

    public double toDeg(double ang)
    {
        return ang * 180 / Math.PI;
    }

}

