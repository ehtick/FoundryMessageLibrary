using System;
using System.Collections.Generic;

namespace IoBTMessage.Units
{

	public class SpanInt : MeasuredValue<int>
	{
		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("SpanInt");
		};

		public SpanInt() :
			base(UnitFamilyName.SpanInt)
		{
		}

		public SpanInt(int value, string? units = null) :
			base(UnitFamilyName.SpanInt)
		{
			var cat = Category();
			I = cat.BaseUnits().Name();
			U = units ?? I;
			V = cat.ConvertFrom(U, value);
		}

		public int Diff(SpanInt other)
		{
			return Value() - other.Value();
		}

		public override int As(string units)
		{
			return Category().ConvertTo(units, V);
		}

		public static SpanInt operator +(SpanInt left, int right) => new(left.Value() + right, left.Internal());
		public static SpanInt operator -(SpanInt left, int right) => new(left.Value() - right, left.Internal());

		public static SpanInt operator +(SpanInt left, SpanInt right) => new(left.Value() + right.Value(), left.Internal());
		public static SpanInt operator -(SpanInt left, SpanInt right) => new(left.Value() - right.Value(), left.Internal());
	}
}