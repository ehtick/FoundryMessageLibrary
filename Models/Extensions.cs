
namespace IoBTMessage.Models;


public static class IoBTMath
{

    public static double toDouble(string Value)
    {
        if (Value == null)
        {
            return 0;
        }
        else
        {
            double.TryParse(Value, out double OutVal);

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

