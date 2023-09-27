using System.Xml.Linq;

namespace IoBTMessage.Models
{

	public class DO_Component : DO_AssemblyItem
	{
	}

	[System.Serializable]
	public class DT_Component : DT_AssemblyItem
	{

		public DT_Component() : base()
		{
		}

		public DT_Component ShallowCopy()
		{
			var result = (DT_Component)this.MemberwiseClone();
			if (part != null)
				result.part = (DT_Part)part.ShallowCopy();
			result.heroImage = this.heroImage;

			return result;
		}

	}

}