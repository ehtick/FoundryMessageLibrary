using System;
using System.Globalization;

namespace IoBTMessage.Units
{
	public class MeasuredValue<T> : IFormattable
	{

		public T V;
		public string I = "";      //internal storage units
		protected string U = "";  //reporting  input and output units
		protected UnitFamilyName F = UnitFamilyName.None;



		public MeasuredValue(UnitFamilyName unitFamily)
		{
			V = default!;
			F = unitFamily;
		}

		public T Value() { return V; }
		public string Units() { return U; }
		public string Internal() { return I; }

		public string extra(string ex) { return $"{I}{ex}"; }




		public void SetDisplayUnits(string units)
		{
			U = units;
		}

		public virtual T As(string units)
		{
			return default!;
		}
		public override string ToString()
		{
			return AsString(Units());
		}

		public string ToString(string format, IFormatProvider provider)
		{
			var value = As(Units());
			return $"{value} {Units()}";
		}

		public string AsString(string units)
		{
			return $"{As(units)} {units}";
		}

		public string Debug()
		{
			return $"{Value()}({Internal()}) {Units()}";
		}


	}
}