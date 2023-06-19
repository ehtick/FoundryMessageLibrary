using System;
using System.Collections.Generic;

namespace IoBTMessage.Units
{

	public class Temperature : MeasuredValue<double>
	{

		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Temperature");
		};

		public Temperature() :
			base(UnitFamilyName.Temperature)
		{
		}

		public Temperature(double value, string? units = null) :
			base(UnitFamilyName.Temperature)
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

		public static Temperature operator +(Temperature left, Temperature right) => new(left.Value() + right.Value(), left.Internal());
		public static Temperature operator -(Temperature left, Temperature right) => new(left.Value() - right.Value(), left.Internal());
	}
}
