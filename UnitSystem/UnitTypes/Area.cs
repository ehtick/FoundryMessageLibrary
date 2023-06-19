using System;
using System.Collections.Generic;

namespace IoBTMessage.Units
{

	public class Area : MeasuredValue<double>
	{


		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Area");
		};

		public Area() :
			base(UnitFamilyName.Area)
		{
		}

		public Area(double value, string? units = null) :
			base(UnitFamilyName.Area)
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

		public static Area operator +(Area left, Area right) => new(left.Value() + right.Value(), left.Internal());
		public static Area operator -(Area left, Area right) => new(left.Value() - right.Value(), left.Internal());
	}
}