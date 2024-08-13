using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using FoundryRulesAndUnits.Extensions;
using FoundryRulesAndUnits.Models;

namespace IoBTMessage.Models
{

	public class DO_Component : DO_Ingredient
	{
	}

	[System.Serializable]
	public class DT_Component : DT_Ingredient
	{
		public List<DT_Component> members;

		public DT_Component() : base()
		{
		}
		public override List<DT_Hero> Children()
		{
			if (members == null) return base.Children();
			return members.Select(item => (DT_Hero)item).ToList();
		}

		public void ClearMembers()
		{
			members = null;
		}
		public List<DT_Component> GetMembers()
		{
			members ??= new List<DT_Component>();
			return members;
		}

		public DT_Component AddMember(DT_Component child)
		{
			members ??= new List<DT_Component>();
			child.parentGuid = this.guid;
			members.Add(child);
			return child;
		}
		
		public override DT_Component ShallowCopy()
		{
			var result = (DT_Component)this.MemberwiseClone();
			if (part != null)
				result.part = (DT_Part)part.ShallowCopy();
			result.heroImage = this.heroImage;

			return result;
		}

		public List<DT_Component> ShallowMembers()
		{
			var result = members?.Select(obj => obj.ShallowCopy()).ToList();
			return result;
		}



	}

}