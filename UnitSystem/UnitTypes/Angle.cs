using System;
using System.Collections.Generic;


namespace IoBTMessage.Units
{
	public class Angle : MeasuredValue<double>
	{
		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Speed");
		};


		public Angle(double value, string? units = null) :
			base(UnitFamilyName.Angle)
		{
			var cat = Category();
			I = cat.BaseUnits().Name();
			U = units ?? I;
			V = cat.ConvertFrom(U, value);
		}



		public override double As(string units)
		{
			return Category().ConvertTo(units, V);
		}

		public Angle Degrees(double value)
		{
			var cat = Category();
			V = cat.ConvertFrom("D", value);
			return this;
		}

		public static Angle operator +(Angle left, Angle right) => new(left.Value() + right.Value(), left.Internal());
		public static Angle operator -(Angle left, Angle right) => new(left.Value() - right.Value(), left.Internal());

	}
}
