using System;
using System.Collections.Generic;
using System.Linq;


namespace IoBTMessage.Models;



public partial class Location : UDTO_Base

{
	public double lat;
	public double lng;
	public double alt;

#if !UNITY
	public Location():base()
    {
    }

    public Location(Location obj):base()
    {
        lat = obj.lat;
        lng = obj.lng;
        alt = obj.alt;
    }

    public Location AsLocation()
    {
        return new Location(this);
    }

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

#endif
}

