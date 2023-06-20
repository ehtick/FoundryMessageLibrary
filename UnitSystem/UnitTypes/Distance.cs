using System;
using System.Collections.Generic;


namespace IoBTMessage.Units
{
	public class Distance : MeasuredValue<double>
	{
		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Distance");
		};

		public Distance():
			base(UnitFamilyName.Length)
		{
		}

		public Distance(double value, string? units = null):
			base(UnitFamilyName.Length)
		{
			var cat = Category();
			I = cat.BaseUnits().Name();
			U = units ?? I;
			V = cat.ConvertFrom(U, value);
		}

		public Distance Assign(double value, string? units = null)
		{
			if ( units == I )
			{
				V = value;
			}
			else
			{
				var cat = Category();
				I = cat.BaseUnits().Name();
				U = units ?? I;
				V = cat.ConvertFrom(U, value);
			}
			return this;
		}

		public Distance Copy()
		{
			return new Distance(Value(), Internal());
		}

		public double Diff(Length other)
		{
			return Value() - other.Value();
		}
		public double Diff(double other)
		{
			return Value() - other;
		}
		public double Sum(Length other)
		{
			return Value() + other.Value();
		}

		public double Sum(double other)
		{
			return Value() + other;
		}



		public override double As(string units)
		{
			return Category().ConvertTo(units, V);
		}

		public static Distance operator +(Distance left, double right) => new(left.Value() + right, left.Internal());
		public static Distance operator -(Distance left, double right) => new(left.Value() - right, left.Internal());

		public static Distance operator +(Distance left, Distance right) => new(left.Value() + right.Value(), left.Internal());
		public static Distance operator -(Distance left, Distance right) => new(left.Value() - right.Value(), left.Internal());

	}
}
