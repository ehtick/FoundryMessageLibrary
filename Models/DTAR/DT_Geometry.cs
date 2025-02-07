using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using FoundryRulesAndUnits.Extensions;
using FoundryRulesAndUnits.Models;

namespace IoBTMessage.Models
{

	public class DO_Geometry : DO_Ingredient
	{
	}

	[System.Serializable]
	public class DT_Geometry : DT_Ingredient
	{
		public string text;
		public UDTO_HighResPosition position;
		public UDTO_BoundingBox boundingBox;

		public List<DT_Geometry> members;

		public DT_Geometry() : base()
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
		public List<DT_Geometry> GetMembers()
		{
			members ??= new List<DT_Geometry>();
			return members;
		}

		public DT_Geometry AddMember(DT_Geometry child)
		{
			members ??= new List<DT_Geometry>();
			child.parentGuid = this.guid;
			members.Add(child);
			return child;
		}
		
		public override DT_Geometry ShallowCopy()
		{
			var result = (DT_Geometry)this.MemberwiseClone();
			if (part != null)
				result.part = (DT_Part)part.ShallowCopy();
			result.heroImage = this.heroImage;

			return result;
		}

		public List<DT_Geometry> ShallowMembers()
		{
			var result = members?.Select(obj => obj.ShallowCopy()).ToList();
			return result;
		}



	}

}