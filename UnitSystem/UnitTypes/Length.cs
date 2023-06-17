using System;
using System.Collections.Generic;


namespace IoBTMessage.Units
{
	public class Length : MeasuredValue<double>
	{
		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Length");
		};


		public Length(double value, string? units = null) :
			base(UnitFamilyName.Length)
		{
			var cat = Category();
			I = cat.BaseUnits().Name();
			U = units ?? I;
			V = cat.ConvertFrom(U, value);
		}

		public static Length FromMeters(double v)
		{
			return new Length(v, "m");
		}

		public override double As(string units)
		{
			return Category().ConvertTo(units, V);
		}


		public static Length operator +(Length left, Length right) => new(left.Value() + right.Value(), left.Internal());
		public static Length operator -(Length left, Length right) => new(left.Value() - right.Value(), left.Internal());

		public static Area operator *(Length left, Length right) => new(left.Value() * right.Value(), "m2");

		public static Volume operator *(Area left, Length right) => new(left.Value() * right.Value(), "m3");
		public static Volume operator *(Length left, Area right) => new(left.Value() * right.Value(), "m3");
	}
}
