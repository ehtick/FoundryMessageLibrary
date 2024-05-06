using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models
{
	public enum SignalElementType
	{
		Unknown,
		Equipment,
		Port,
		Link,
		Harness
	}

	public class DO_Signal : DT_Component
	{
		public string signal { get; set; }
		public SignalElementType signalElementType { get; set; } = SignalElementType.Unknown;

		public string StartPortReference { get; set; }
		public string FinishPortReference { get; set; }
	}

	[System.Serializable]
	public class DT_Signal : DT_Component, ISystem
	{
		public string signal;
		public SignalElementType signalElementType = SignalElementType.Unknown;

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

		public DT_Signal MarkAsEquipment()
		{
			signalElementType = SignalElementType.Equipment;
			return this;
		}

		public DT_Signal MarkAsPort()
		{
			signalElementType = SignalElementType.Port;
			return this;
		}

		public DT_Signal MarkAsLink()
		{
			signalElementType = SignalElementType.Link;
			return this;
		}

		public DT_Signal MarkAsHarness()
		{
			signalElementType = SignalElementType.Harness;
			return this;
		}

		public bool IsEquipment()
		{
			return signalElementType == SignalElementType.Equipment;
		}

		public bool IsPort()
		{
			return signalElementType == SignalElementType.Port;
		}

		public bool IsLink()
		{
			return signalElementType == SignalElementType.Link;
		}

		public bool IsHarness()
		{
			return signalElementType == SignalElementType.Harness;
		}

	}
}


