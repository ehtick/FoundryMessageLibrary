using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using FoundryRulesAndUnits.Extensions;
using FoundryRulesAndUnits.Models;

namespace IoBTMessage.Models
{

	public class DO_Geometry : DO_Component
	{
		public string text { get; set; }
		public HighResPosition position { get; set; }
		public BoundingBox boundingBox { get; set; }
	}

	[System.Serializable]
	public class DT_Geometry : DT_Component
	{
		public string text;
		public HighResPosition position;
		public BoundingBox boundingBox;


		public DT_Geometry() : base()
		{
		}



	}

}