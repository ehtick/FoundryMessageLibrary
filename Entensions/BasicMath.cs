using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoBTMessage;

static public class BasicMath
{
	public static double toDouble(this string Value)
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

	public static int toInteger(this string Value)
	{
		if (Value == null)
		{
			return 0;
		}
		else
		{
			if (int.TryParse(Value, out int OutVal))
			{
				return OutVal;
			}
			return 0;
		}
	}


}

static public class IoBTMath
{
	public static double toDouble(string Value)
	{
		return Value.toDouble();
	}

	public static int toInteger(string Value)
	{
		return Value.toInteger();
	}

	public static double toRad(this double ang)
	{
		return ang * Math.PI / 180;
	}

	public static double toDeg(this double ang)
	{
		return ang * 180 / Math.PI;
	}
}

