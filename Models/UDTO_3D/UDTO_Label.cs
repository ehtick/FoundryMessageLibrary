using FoundryRulesAndUnits.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace IoBTMessage.Models
{
	[System.Serializable]
	public class SPEC_Label : SPEC_Body
	{
		public string size { get; set; }
		public List<string> details { get; set; }
		public string targetGuid { get; set; }
	}
	
	[System.Serializable]
	public class UDTO_Label : UDTO_Body
	{
		public string size;
		public List<string> details;
		public string targetGuid;


		public UDTO_Label() : base()
		{
		}

		public override UDTO_3D CopyFrom(UDTO_3D obj)
		{
			base.CopyFrom(obj);

			var label = obj as UDTO_Label;

			this.size = label.size;
			this.details = label.details;
			this.targetGuid = label.targetGuid;	
					
			if (this.position == null)
			{
				this.position = label.position;
			}
			else if (label.position != null)
			{
				this.position.copyOther(label.position);
			}

			return this;
		}

		public UDTO_Label CreateTextAt(string text, double xLoc = 0.0, double yLoc = 0.0, double zLoc = 0.0)
		{
			this.text = text.Trim();
			this.type = "Label";
			position = new UDTO_HighResPosition(xLoc, yLoc, zLoc);

			return this;
		}

		public UDTO_Label CreateLabelAt(string text, List<string> details = null, double xLoc = 0.0, double yLoc = 0.0, double zLoc = 0.0)
		{
			this.text = text.Trim();
			this.details = details;
			this.type = "Label";

			position = new UDTO_HighResPosition(xLoc, yLoc, zLoc);
			return this;
		}

	}

}