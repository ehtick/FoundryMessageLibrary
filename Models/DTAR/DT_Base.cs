using System;
using FoundryRulesAndUnits.Models;

namespace IoBTMessage.Models
{
	public class DESIGN_Base
	{
		public string guid { get; set; }
		public string parentGuid { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		public string url { get; set; }
		public string timeStamp { get; set; }
		public ControlParameters metadata { get; set; }
	}

	
	public interface ISystem
	{

	}


	public class DO_Searchable : DESIGN_Base
	{
		public string title { get; set; }
		public string description { get; set; }
	}

	[System.Serializable]
	public class DT_Searchable : DT_Base
	{
		public string title;
		public string description;


		public DT_Searchable() : base()
		{
		}

	}

	public class DO_QualityAssurance : DO_Searchable
	{
		public string action { get; set; }
		public string author { get; set; }
		public string componentGuid { get; set; }
	}

	[System.Serializable]
	public class DT_QualityAssurance : DT_Searchable
	{
		public string action;
		public string author;
		public string componentGuid;


		public DT_QualityAssurance() : base()
		{
		}

	}

	public class DO_Comment : DO_Searchable
	{
		public string severity { get; set; }
		public string author { get; set; }
	}

	[System.Serializable]
	public class DT_Comment : DT_Searchable
	{
		public string severity;
		public string author;

		public DT_Comment() : base()
		{
		}
		public DT_Comment OK()
		{
			severity = "OK";
			return this;
		}
		public DT_Comment Error()
		{
			severity = "Error";
			return this;
		}
		public DT_Comment Bug()
		{
			severity = "Bug";
			return this;
		}
		public DT_Comment Comment()
		{
			severity = "Comment";
			return this;
		}
		public DT_Comment MissingReference()
		{
			severity = "Missing";
			return this;
		}

	}
}
