using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models
{
	public enum SignalElementType
	{
		Equipment,
		Port,
		Link,
		Harness
	}

	public class DO_Signal : DT_Component
	{
		public string signal { get; set; }
		public SignalElementType signalElementType { get; set; }

		public string StartPortReference { get; set; }
		public string FinishPortReference { get; set; }
	}

	[System.Serializable]
	public class DT_Signal : DT_Component, ISystem
	{
		public string signal;
		public SignalElementType signalElementType;

		public string StartPortReference;
		public string FinishPortReference;

		public DT_Signal()
		{
		}


		public override DT_Signal ShallowCopy()
		{
			var result = (DT_Signal)this.MemberwiseClone();

			return result;
		}

	}
}


