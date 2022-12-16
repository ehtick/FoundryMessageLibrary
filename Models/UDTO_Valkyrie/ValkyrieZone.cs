using System;
namespace IoBTMessage.Models
{

	public class SPEC_ValkyrieZone
	{
		public double minLatitude { get; set; } = 0;
		public double minLongitude { get; set; } = -180;
		public double maxLatitude { get; set; } = 90;
		public double maxLongitude { get; set; } = 0;
	}

	[System.Serializable]
	public class ValkyrieZone
	{
		public double minLatitude;
		public double minLongitude;
		public double maxLatitude;
		public double maxLongitude;

		public ValkyrieZone()
		{
		}
	}
}

