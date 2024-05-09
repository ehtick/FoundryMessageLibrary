using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FoundryRulesAndUnits.Extensions;

namespace IoBTMessage.Models
{
	public class DO_Signal : DT_Component
	{
		public string signal { get; set; }
		public string signalElementType { get; set; } = "Unknown";

		public string startPortReference { get; set; }
		public string finishPortReference { get; set; }
	}

	[System.Serializable]
	public class DT_Signal : DT_Component, ISystem
	{
		public string signal;
		public string signalElementType { get; set; } = "Unknown";
		public bool isNode { get; set; } = true;

		public string startPortReference;
		public string finishPortReference;

		public List<DT_Signal> children;

		public DT_Signal()
		{
		}

		public void ClearChildren()
		{
			children = null;
		}
		public List<DT_Signal> GetChildren()
		{
			children ??= new List<DT_Signal>();
			return children;
		}

		public DT_Signal AddChild(DT_Signal child)
		{
			children ??= new List<DT_Signal>();
			child.parentGuid = this.guid;
			members.Add(child);
			return child;
		}

		public string SetElement(string elementType)
		{
			signalElementType = elementType.ToUpper();
			return signalElementType;
		}
		public bool IsElement(string elementType)
		{
			return signalElementType.Matches(elementType);
		}


		public override DT_Signal ShallowCopy()
		{
			var result = (DT_Signal)this.MemberwiseClone();
			return result;
		}

		public bool IsConnected()
		{
			return !string.IsNullOrEmpty(this.startPortReference) && !string.IsNullOrEmpty(this.finishPortReference);
		}

		public bool IsDisconnected()
		{
			return string.IsNullOrEmpty(this.startPortReference) && string.IsNullOrEmpty(this.finishPortReference);
		}

		public DT_Signal MarkAsRack()
		{
			isNode = true;
			SetElement("Rack");
			return this;
		}
		public DT_Signal MarkAsEquipment()
		{
			isNode = true;
			SetElement("Equipment");
			return this;
		}

		public DT_Signal MarkAsPort()
		{
			isNode = true;
			SetElement("Port");
			return this;
		}

		public DT_Signal MarkAsCable()
		{
			isNode = false;
			SetElement("Cable");
			return this;
		}

		public DT_Signal MarkAsHarness()
		{
			isNode = false;
			SetElement("Harness");
			return this;
		}



		public bool IsPort()
		{
			return IsElement("Port");
		}

		public bool IsCable()
		{
			return IsElement("Cable");
		}

		public bool IsRack()
		{
			return IsElement("Rack");
		}

		public bool IsEquipment()
		{
			return IsElement("Equipment");
		}

		public bool IsHarness()
		{
			return IsElement("Harness");
		}

		
	}
}


