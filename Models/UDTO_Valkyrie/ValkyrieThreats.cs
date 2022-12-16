using System;
using System.Collections.Generic;

namespace IoBTMessage.Models
{

	public class SPEC_ValkyrieThreats
	{

        public List<string> hiddenThreatIds { get; set; } = new List<string>();
	}

	[System.Serializable]
	public class ValkyrieThreats
	{

		public List<string> hiddenThreatIds = new List<string>();

		public ValkyrieThreats()
		{
		}


	}
}

