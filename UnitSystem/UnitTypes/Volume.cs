using System;
using System.Collections.Generic;

namespace IoBTMessage.Units
{

	public class Volume : MeasuredValue<double>
	{
		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Volume");
		};

		public Volume() :
			base(UnitFamilyName.Volume)
		{
		}

		public Volume(double value, string? units = null) :
			base(UnitFamilyName.Volume)
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


		public static Volume operator +(Volume left, Volume right) => new(left.Value() + right.Value(), left.Internal());
		public static Volume operator -(Volume left, Volume right) => new(left.Value() - right.Value(), left.Internal());
	}
}
