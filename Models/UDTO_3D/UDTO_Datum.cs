using FoundryRulesAndUnits.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace IoBTMessage.Models
{

	
	[System.Serializable]
	public class UDTO_Datum : UDTO_Body
	{


		public UDTO_Datum() : base()
		{
		}

		public override UDTO_3D CopyFrom(UDTO_3D obj)
		{
			base.CopyFrom(obj);

			var node = obj as UDTO_Datum;
			this.text = node.text;

					
			if (this.position == null)
			{
				this.position = node.position;
			}
			else if (node.position != null)
			{
				this.position.copyOther(node.position);
			}
			if (this.boundingBox == null)
			{
				this.boundingBox = node.boundingBox;
			}
			else if (node.boundingBox != null)
			{
				this.boundingBox.copyOther(node.boundingBox);
			}
			return this;
		}

		public UDTO_Datum CreateTextAt(string text, double xLoc = 0.0, double yLoc = 0.0, double zLoc = 0.0)
		{
			this.text = text.Trim();
			this.type = "Datum";
			position = new UDTO_HighResPosition(xLoc, yLoc, zLoc);

			return this;
		}

		public UDTO_Datum CreateLabelAt(string text, List<string> details = null, double xLoc = 0.0, double yLoc = 0.0, double zLoc = 0.0)
		{
			this.text = text.Trim();
			this.type = "Datum";

			position = new UDTO_HighResPosition(xLoc, yLoc, zLoc);

			return this;
		}
	}

}