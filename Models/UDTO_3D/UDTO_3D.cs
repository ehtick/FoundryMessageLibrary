using FoundryRulesAndUnits.Models;

namespace IoBTMessage.Models
{

	public class SPEC_3D : SPEC_Base
	{
		public bool visible  { get; set; } = true;
		public string platformName { get; set; }
		public string uniqueGuid { get; set; }
		public string type { get; set; }
		public string name { get; set; }
		public string material { get; set; }
		public string referenceDesignation { get; set; }
		public string sourceURL { get; set; }
		public ControlParameters metadata { get; set; }
	}
	[System.Serializable]
	public class UDTO_3D : UDTO_Base
	{
		
		public bool visible = true;
		public string type;
		public string name;
		public string material;
		public string uniqueGuid;
		public string parentUniqueGuid;

		public string sourceURL;
		public DT_System subSystem;
		public DT_Part part;


		public UDTO_3D(): base()
		{
		}
		
		public virtual UDTO_3D CopyFrom(UDTO_3D obj)
		{
			uniqueGuid = obj.uniqueGuid;
			type = obj.type;
			name = obj.name;
			part = obj.part;
			return this;
		}

		public DT_Part GetPart()
		{
			part ??= new DT_Part() {
					partNumber = name,
					version = "1.0"
				};
			return part;
		}

		public DT_Hero AsHero()
		{
			var hero = new DT_Hero()
			{
				guid = uniqueGuid,
				name = name,
				title = partName()
			};
			return hero;
		}

		public string partName()
		{
			if ( part == null)
				return name;

			return $"{name}_{part.structureReference}";
		}
		public bool isDelete()
		{
			return this.type == "Command:DELETE";
		}

		public bool isVisible()
		{
			return this.visible;
		}

		public UDTO_3D setVisible(bool visible)
		{
			this.visible = visible;
			return this;
		}
	}
}
