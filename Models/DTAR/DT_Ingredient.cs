﻿using System.Text.Json.Serialization;
using FoundryRulesAndUnits.Models;
using FoundryRulesAndUnits.Extensions;

namespace IoBTMessage.Models
{

	public class DO_Ingredient : DT_Hero
	{
		//public DO_Part part { get; set; }
		public string parentName { get; set; }
		public string systemName { get; set; }
	}

	//[JsonDerivedType(typeof(DT_Geometry))]
	[JsonDerivedType(typeof(DT_Component))]
	[JsonDerivedType(typeof(DT_Sensor))]
	[System.Serializable]
	public class DT_Ingredient : DT_Hero, ISystem
	{
		public DT_Part part;
		public string parentName;
		public string systemName;
		public string category;

		public DT_Ingredient() : base()
		{
		}


		public DT_Part GetPart()
		{
			part ??= new DT_Part() { partNumber = name };
			return part;
		}
		public string ComputeTitle()
		{
			var title = GetPart().ComputeTitle();
			return title;
		}

		public virtual DT_Ingredient ShallowCopy()
		{
			var result = (DT_Ingredient)this.MemberwiseClone();
			if (part != null)
				result.part = (DT_Part)part.ShallowCopy();
				
			result.heroImage = this.heroImage;
			result.parentName = this.parentName;
			result.systemName = this.systemName;
			result.category = this.category;

			return result;
		}

		public string SetCatagory(string elementType)
		{
			category = elementType.ToUpper();
			return category;
		}
		public bool IsCatagory(string elementType)
		{
			return category.Matches(elementType);
		}
	}






}