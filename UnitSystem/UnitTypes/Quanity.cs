using System;
using System.Collections.Generic;


namespace IoBTMessage.Units
{
	public class Quanity : MeasuredValue<double>
	{
		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Quanity");
		};


		public Quanity(double value, string? units = null) :
			base(UnitFamilyName.Quanity)
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


		public static Quanity operator +(Quanity left, int right) => new(left.Value() + right, left.Internal());
		public static Quanity operator -(Quanity left, int right) => new(left.Value() - right, left.Internal());

		public static Quanity operator +(Quanity left, Quanity right) => new(left.Value() + right.Value(), left.Internal());
		public static Quanity operator -(Quanity left, Quanity right) => new(left.Value() - right.Value(), left.Internal());

	}
}
