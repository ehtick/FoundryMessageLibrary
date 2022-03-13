using System;

namespace ApprenticeNET
{
	/// <summary>
	/// Summary description for Units.
	/// </summary>
	public class Units : SemanticObject
	{
		private string m_sDataTypeMapping = null;

		private UnitCategory m_oUnitCategory = null;

		public Units() :base()
		{
		}
		public Units(string sName) :base(sName)
		{
		}
		public string FormatTypeMapping(string sFormula, bool bBaseUnits)
		{
			if ( m_sDataTypeMapping != null )
				return string.Format("{0}({1})", m_sDataTypeMapping, sFormula ); 

			return ( bBaseUnits ) ? FormatBaseValue(sFormula) : FormatUnitValue(sFormula);
		}
		public string FormatBaseValue(string sFormula)
		{
			if ( sFormula.Length == 0 )
				return sFormula;

			if ( sFormula == "." )
				return "0.0";
			
			string sUnits =  Name.IndexOf("@") == -1 ? WrapDQ(Name) : Name;
			return string.Format("BaseValue({0},{1})", sFormula, sUnits);
		}
		public string FormatUnitValue(string sFormula)
		{
			if ( sFormula.Length == 0 )
				return sFormula;

			if ( sFormula == "." )
				return "0.0";
			
			string sUnits =  Name.IndexOf("@") == -1 ? WrapDQ(Name) : Name;
			return string.Format("UnitValue({0},{1})", sFormula, sUnits);
		}

		public ObjectCollection MembersOfCatagory()
		{
			return MembersOfCatagory(Category);
		}
		public ObjectCollection MembersOfCatagory(string sCategory)
		{
			ObjectCollection oList = NewCollection();
			ContentManager oManager = ParentOfType(typeof(ContentManager)) as ContentManager;

			foreach(Units oUnits in oManager.UnitsFolder.Slots)
				if ( oUnits.Category == sCategory )
					oList.Add(oUnits);

			return oList;
		}
		public virtual string LookUpKey(InstanceObject oSponsor)
		{
			string sName = Name;
			if ( sName.IndexOf("@") == -1 || oSponsor == null )
				return sName;
				
			object oObject = oSponsor.Evaluate(sName);
			return oObject != null ? oObject.ToString() : "";
		}
		public virtual string LookUpCaption(InstanceObject oSponsor)
		{
			string sName = Name;
			if ( sName.IndexOf("@") == -1 || oSponsor == null )
				return Caption;
				
			return oSponsor.Evaluate(sName).ToString();
		}

		public bool HasUnitCategory(InstanceObject oSponsor)
		{
			if ( m_oUnitCategory != null )
				return true;

			string sName = Name;
			if ( sName.IndexOf("@") == -1 || oSponsor == null )
				return true;

			sName = oSponsor.Evaluate(sName).ToString();

			ContentManager oManager = ParentOfType(typeof(ContentManager)) as ContentManager;

			foreach(Units oUnits in oManager.Units())
				if ( oUnits.IsNamed(sName) )
				{
					m_oUnitCategory = oUnits.UnitCategory;
					return true;
				}

			return false;
		}
		public virtual UnitCategory UnitCategory
		{
			get
			{
				if ( m_oUnitCategory != null )
					return m_oUnitCategory;

				ContentManager oManager = ParentOfType(typeof(ContentManager)) as ContentManager;

				foreach(UnitCategory oUnitCategory in oManager.UnitCategories())
					if ( oUnitCategory.IsNamed(Category) )
					{
						m_oUnitCategory = oUnitCategory;
						break;
					}


				return m_oUnitCategory;
			}
			set
			{
				Category = "";
				if ( value == null )
					m_oUnitCategory = value;
				else if ( value.Name.IndexOf("@") != -1 )
					m_oUnitCategory = null;
				else
				{
					m_oUnitCategory = value;
					Category = m_oUnitCategory.Name;
				}
			}

		}
		public object ToBaseUnitCategory(double dValue, InstanceObject oSponsor)
		{
			try
			{
				if ( HasUnitCategory(oSponsor) )
					return UnitCategory.ConvertFrom(dValue,this,oSponsor);
			}
			catch (Exception e)
			{
				ApprenticeObject.ReportException(e);
				return null;
			}
			return dValue;
		}
		public object FromBaseUnitCategory(double dValue, InstanceObject oSponsor)
		{
			try
			{
				if ( HasUnitCategory(oSponsor) )
					return UnitCategory.ConvertTo(dValue,this,oSponsor);
			}
			catch (Exception e)
			{
				ApprenticeObject.ReportException(e);
				return null;
			}
			return dValue;
		}
		public virtual string MappingFunction
		{
			get
			{
				return (m_sDataTypeMapping == null) ? "" : m_sDataTypeMapping;
			}
			set
			{
				m_sDataTypeMapping = value;
			}
		}
	}
}
