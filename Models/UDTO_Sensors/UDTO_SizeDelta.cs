
using FoundryRulesAndUnits.Models;



namespace IoBTMessage.Models
{



	[System.Serializable]
	public class UDTO_SizeDelta : UDTO_SensorBase
	{
		public BoundingBox size;
	}
}