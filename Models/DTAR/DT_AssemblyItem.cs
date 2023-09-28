using System.Text.Json.Serialization;


namespace IoBTMessage.Models
{

	public class DO_AssemblyItem : DO_Title
	{
		public DO_Part part { get; set; }
		public string parentAssembly { get; set; }
		public string systemName { get; set; }
	}

	[JsonDerivedType(typeof(DT_Component))]
	[JsonDerivedType(typeof(DT_Sensor))]
	[System.Serializable]
	public class DT_AssemblyItem : DT_Hero, ISystem
	{
		public DT_Part part;
		public string parentAssembly;
		public string systemName;

		public DT_AssemblyItem() : base()
		{
		}


		public DT_Part GetPart()
		{
			part ??= new DT_Part() { partNumber = name };
			return part;
		}
		public string ComputeTitle()
		{
			var title = GetPart().ComputeTitle();
			return title;
		}

		public virtual DT_AssemblyItem ShallowCopy()
		{
			var result = (DT_AssemblyItem)this.MemberwiseClone();
			if (part != null)
				result.part = (DT_Part)part.ShallowCopy();
			result.heroImage = this.heroImage;

			return result;
		}
	}






}