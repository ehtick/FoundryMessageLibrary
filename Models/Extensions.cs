
namespace IoBTMessage.Models;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;

public static class IoBTMath
{

    public static IPosition asCoord(Feature<Point> point)
    {
        return point.Geometry.Coordinates;
    }

    public static double asLat(Feature<Point> point)
    {
        return point.Geometry.Coordinates.Latitude;
    }


    public static double asLng(Feature<Point> point)
    {
        return point.Geometry.Coordinates.Longitude;
    }

    public static double toDouble(string Value)
    {
        if (Value == null)
        {
            return 0;
        }
        else
        {
            double OutVal;
            double.TryParse(Value, out OutVal);

            if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
            {
                return 0;
            }
            return OutVal;
        }
    }

    public static int toInteger(string Value)
    {
        if (Value == null)
        {
            return 0;
        }
        else
        {
            int OutVal;
            if ( int.TryParse(Value, out OutVal) ) {
                return OutVal;
            }
            return 0;
        }
    }
}

