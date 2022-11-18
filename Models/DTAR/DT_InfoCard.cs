namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_InfoCard
	{
		public string distribution;
		public string revision;

		public DT_InfoCard() : base()
		{

		}
		public DT_InfoCard ShallowCopy()
		{
			var result = (DT_InfoCard)this.MemberwiseClone();
			return result;
		}



		public string ComputeTitle()
		{
			var title = $"{distribution}";

			return title;
		}
	}






}