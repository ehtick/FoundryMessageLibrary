using System;
using System.Collections.Generic;


namespace IoBTMessage.Units
{
	public class Time : MeasuredValue<double>
	{
		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Time");
		};

		public Time() :
			base(UnitFamilyName.Time)
		{
		}

		public Time(double value, string? units = null) :
			base(UnitFamilyName.Duration)
		{
			var cat = Category();
			I = cat.BaseUnits().Name();
			U = units ?? I;
			V = cat.ConvertFrom(U, value);
		}

		public static Duration Zero { get { return new Duration(0,"s"); } }

		public static Duration FromDays(double v)
		{
			return new Duration(v, "d");
		}

		public static Duration FromSeconds(double v)
		{
			return new Duration(v, "s");
		}

		public override double As(string units)
		{
			return Category().ConvertTo(units, V);
		}



		public static Time operator +(Time left, Time right) => new(left.Value() + right.Value(), left.Internal());
		public static Time operator -(Time left, Time right) => new(left.Value() - right.Value(), left.Internal());

		//public static bool operator <=(Time left, Duration right) => left.Value() <= right.Value();
		//public static bool operator >=(Time left, Time right) => left.Value() >= right.Value();

	}
}
