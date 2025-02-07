using System;
using System.Collections.Generic;
using System.Linq;
using FoundryRulesAndUnits.Extensions;
using FoundryRulesAndUnits.Models;

namespace IoBTMessage.Models
{


	[System.Serializable]
	public class UDTO_Pathway : UDTO_3D
	{
		public List<UDTO_Body> datums = new();

		public UDTO_Pathway() : base()
		{
			uniqueGuid = Guid.NewGuid().ToString();
			type = UDTO_Base.asTopic<UDTO_Pathway>();
		}


		public UDTO_Body FindDatum(string name)
		{
			var found = datums.Where( obj => obj.name.Matches(name)).FirstOrDefault();
			return found;
		}

		public UDTO_Body EstablishDatum(string name, double x = 0.0, double y = 0.0, double z = 0.0)
		{
			var datum = FindDatum(name);
			if (datum == null)
			{
				datum = new UDTO_Body() {
					name = name,
					position = new UDTO_HighResPosition(x,y,z),
				};
				datums.Add(datum);
			}

			return datum;
		}


		public UDTO_Pathway Flush()
		{
			datums.Clear();
			return this;
		}

		public UDTO_Pathway AsShallowCopy()
		{
			var result = (UDTO_Pathway)this.MemberwiseClone();
			result.Flush();
			return result;
		}	

	}

}