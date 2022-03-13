using System;
using System.Collections;


namespace ApprenticeNET
{
	/// <summary>
	/// Summary description for UnitCategory.
	/// </summary>
	public class UnitCategory : SemanticObject
	{
		private Hashtable m_oConvert = new Hashtable(10);

		private Units m_oBaseUnits = null;

		public UnitCategory() :base()
		{
		}
		public UnitCategory(string sName) :base(sName)
		{
		}
		public virtual Units BaseUnits
		{
			get { 
				return m_oBaseUnits; 
			}
			set { 
				m_oBaseUnits = value; 
			}
		}
		public void Conversion(double dValue1, string sUnits1, double dValue2, string sUnits2)
		{
			if ( sUnits1 == sUnits2 )
				return;

			ContentManager oManager = ParentOfType(typeof(ContentManager)) as ContentManager;
			oManager.UnitsU(sUnits1);
			oManager.UnitsU(sUnits2);

			double dConvert1 = dValue1 / dValue2;
			if ( double.IsNaN(dConvert1) || double.IsInfinity(dConvert1) )
				return;

			string sKey1 = string.Format("{0}|{1}", sUnits1, sUnits2).ToLower();
			if ( !m_oConvert.ContainsKey(sKey1) )
				m_oConvert.Add(sKey1, dConvert1);

			double dConvert2 = dValue2 / dValue1;
			if ( double.IsNaN(dConvert2) || double.IsInfinity(dConvert2) )
				return;

			string sKey2 = string.Format("{0}|{1}", sUnits2, sUnits1).ToLower();
			if ( !m_oConvert.ContainsKey(sKey2) )
				m_oConvert.Add(sKey2, dConvert2);
		}
		public double ConvertFrom(double dValue, Units oUnits, InstanceObject oSponsor)
		{
			try
			{
				if ( oUnits.IsNamed(BaseUnits.LookUpKey(oSponsor)) )
					return dValue;

				string sKey = string.Format("{0}|{1}", BaseUnits.LookUpKey(oSponsor), oUnits.LookUpKey(oSponsor)).ToLower();

				if ( !m_oConvert.ContainsKey(sKey) )
				{
					string sRational = string.Format("Conversion from {0} does not exist. Add this to the units table.", sKey);
					ApprenticeObject.ReportException(sRational); 
					return dValue;
				}

				double dConvert = (double)m_oConvert[sKey];
				double dNewValue = dConvert * dValue;
				return dNewValue;
			}
			catch(Exception e)
			{
				ReportException(e);
			}
			return dValue;
		}

		public double ConvertTo(double dValue, Units oUnits, InstanceObject oSponsor)
		{
			try
			{
				if ( oUnits.IsNamed(BaseUnits.LookUpKey(oSponsor)) )
					return dValue;

				string sKey = string.Format("{0}|{1}", oUnits.LookUpKey(oSponsor), BaseUnits.LookUpKey(oSponsor) ).ToLower();

				if ( !m_oConvert.ContainsKey(sKey) )
				{
					string sRational = string.Format("Conversion to {0} does not exist. Add this to the units table.", sKey);
					ApprenticeObject.ReportException(sRational); 
					return dValue;
				}

				double dConvert = (double)m_oConvert[sKey];
				double dNewValue = dConvert * dValue;
				return dNewValue;
			}
			catch(Exception e)
			{
				ReportException(e);
			}
			return dValue;
		}
	}
}
