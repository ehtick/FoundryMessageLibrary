using System.Collections.Generic;
using FoundryRulesAndUnits.Models;

namespace IoBTMessage.Models
{


	[System.Serializable]
	public class SPEC_Body : SPEC_3D
	{
		public UDTO_HighResPosition position { get; set; }
		public UDTO_BoundingBox boundingBox { get; set; }
	}

	[System.Serializable]
	public class UDTO_Body : UDTO_3D
	{
		public string text;
		public UDTO_HighResPosition position;
		public UDTO_BoundingBox boundingBox;

		public string category;
		public List<UDTO_Body> members;

		public UDTO_Body() : base()
		{
		}

		public bool HasMembers()
		{
			return members != null && members.Count > 0;
		}
		public void ClearMembers()
		{
			members = null;
		}
		public List<UDTO_Body> GetMembers()
		{
			members ??= new List<UDTO_Body>();
			return members;
		}

		public UDTO_Body AddMember(UDTO_Body child)
		{
			members ??= new List<UDTO_Body>();
			child.parentUniqueGuid = this.uniqueGuid;
			members.Add(child);
			return child;
		}
		public override UDTO_3D CopyFrom(UDTO_3D obj)
		{
			base.CopyFrom(obj);

			var body = obj as UDTO_Body;
			this.sourceURL = body!.sourceURL;
			this.text = body.text;

			if (this.position == null)
			{
				this.position = body.position;
			}
			else if (body.position != null)
			{
				this.position.copyOther(body.position);
			}

			if (this.boundingBox == null)
			{
				this.boundingBox = body.boundingBox;
			}
			else if (body.boundingBox != null)
			{
				this.boundingBox.copyOther(body.boundingBox);
			}
			return this;
		}

		public UDTO_Body EstablishLoc(HighResPosition pos)
		{
			position ??= new UDTO_HighResPosition();
			position.copyFrom(pos);
			return this;
		}

		public UDTO_Body EstablishLoc(double x = 0.0, double y = 0.0, double z = 0.0)
		{
			position ??= new UDTO_HighResPosition();
			position.Loc(x, y, z);
			return this;
		}
		public UDTO_Body EstablishAng(double x = 0.0, double y = 0.0, double z = 0.0)
		{
			position ??= new UDTO_HighResPosition();
			position.Ang(x, y, z);
			return this;
		}
		public UDTO_Body EstablishBox(BoundingBox box)
		{
			boundingBox ??= new UDTO_BoundingBox();
			boundingBox.copyFrom(box);
			return this;
		}

		public UDTO_Body EstablishBox(double width = 1.0, double height = 1.0, double depth = 1.0)
		{
			boundingBox ??= new UDTO_BoundingBox();
			boundingBox.Box(width, height, depth);
			return this;
		}

		public UDTO_Body EstablishPivot(double px = 0.0, double py = 0.0, double pz = 0.0)
		{
			boundingBox ??= new UDTO_BoundingBox();

			boundingBox.Pin(px, py, pz);
			return this;
		}

	}

}