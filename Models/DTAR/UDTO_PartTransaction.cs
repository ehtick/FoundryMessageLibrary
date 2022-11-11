
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{

	[System.Serializable]
	public class UDTO_PartTransation : UDTO_Base
	{
		public DT_Part part;
		public double quantity;
		public string note;

#if !UNITY

#endif
	}
}