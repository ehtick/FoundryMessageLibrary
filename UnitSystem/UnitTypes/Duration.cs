using System;
using System.Collections.Generic;


namespace IoBTMessage.Units
{
	public class Duration : MeasuredValue<double>
	{
		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Duration");
		};


		public Duration(double value, string? units = null) :
			base(UnitFamilyName.Duration)
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



		public static Duration operator +(Duration left, Duration right) => new(left.Value() + right.Value(), left.Internal());
		public static Duration operator -(Duration left, Duration right) => new(left.Value() - right.Value(), left.Internal());

	}
}
