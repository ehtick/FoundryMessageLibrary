using System;
using System.Collections.Generic;


namespace IoBTMessage.Units
{
	public class Speed : MeasuredValue<double>
	{
		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Speed");
		};

		public Speed() :
			base(UnitFamilyName.Speed)
		{
		}

		public Speed(double value, string? units = null) :
			base(UnitFamilyName.Speed)
		{
			var cat = Category();
			I = cat.BaseUnits().Name();
			U = units ?? I;
			V = cat.ConvertFrom(U, value);
		}

		public static Speed FromMetersPerSecond(double v)
		{
			return new Speed(v, "m/s");
		}

		public override double As(string units)
		{
			return Category().ConvertTo(units, V);
		}


		public static Speed operator +(Speed left, Speed right) => new(left.Value() + right.Value(), left.Internal());
		public static Speed operator -(Speed left, Speed right) => new(left.Value() - right.Value(), left.Internal());

	}
}
