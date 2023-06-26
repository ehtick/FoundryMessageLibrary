using IoBTMessage.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IoBTMessage.Units
{
	//[JsonConverter(typeof(AngleJsonConverter))]
	public class Angle : MeasuredValue
	{
		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Angle");
		};

		public Angle() :
			base(UnitFamilyName.Angle)
		{
		}


		public Angle(double value, string units = null) :
			base(UnitFamilyName.Angle)
		{
			Init(Category(), value, units);
		}

		public Angle Assign(double value, string units = null)
		{
			if (units == I)
			{
				V = value;
			}
			else
			{
				Init(Category(), value, units);
			}
			return this;
		}

		public Angle Assign(Angle source)
		{
			if (source.I == I)
			{
				V = source.Value();
			}
			else
			{
				Init(Category(), source.Value(), source.U);
			}
			return this;
		}

		public Angle Copy()
		{
			return new Angle(Value(), Internal());
		}

		public static Angle FromDegrees(double v)
		{
			return new Angle(v, "D");
		}

		public static Angle FromRadians(double v)
		{
			return new Angle(v, "r");
		}

		public override double As(string units)
		{
			return ConvertAs(Category(), units);
		}

		public Angle Degrees(double value)
		{
			var cat = Category();
			V = cat.ConvertToBaseUnits("d", value);
			return this;
		}

		public static Angle operator +(Angle left, Angle right) => new(left.Value() + right.Value(), left.Internal());
		public static Angle operator -(Angle left, Angle right) => new(left.Value() - right.Value(), left.Internal());

	}

	public class AngleJsonConverter : JsonConverter<Angle>
	{
		public override Angle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			double value = 0;
			string units = "";
			string internalUnits = "";

			$"typeToConvert {typeToConvert} ".WriteLine();

			while (reader!.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
				{
					var result = new Angle(value, internalUnits);
					if (!string.IsNullOrEmpty(units))
						result!.SetDisplayUnits(units);
					return result;
				}

				var propertyName = reader!.GetString();

				reader.Read();

				switch (propertyName)
				{
					case "I":
					case "i":
						internalUnits = reader!.GetString();
						break;
					case "U":
					case "u":
						units = reader!.GetString();
						break;
					case "V":
					case "v":
						value = reader!.GetDouble();
						break;
				}
			}
			return new Angle(value, internalUnits);
		}

		public override void Write(Utf8JsonWriter writer, Angle dataValue, JsonSerializerOptions options)
		{
			//dataValue.V = 200;
		}
	}

}
