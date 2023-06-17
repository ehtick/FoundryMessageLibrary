namespace IoBTMessage.Units
{

	public class UnitSpec
	{
		protected string name { get; set; }
		protected string title { get; set; }
		protected UnitFamilyName family { get; set; }

		public UnitSpec(string units)
		{
			this.name = units;
			this.family = UnitFamilyName.None;
			this.title = units;
		}

		public UnitSpec(string units, string title, UnitFamilyName unitFamily)
		{
			this.name = units;
			this.family = unitFamily;
			this.title = title;
		}

		public string Title() { return title; }
		public string Name() { return name; }
		public UnitFamilyName UnitFamily() { return family; }
	}
}

















