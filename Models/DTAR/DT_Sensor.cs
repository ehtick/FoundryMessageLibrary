using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace IoBTMessage.Models
{

	public class DO_Sensor : DO_AssemblyItem
	{
		public string topic { get; set; }
		public string sourceGuid { get; set; }
	}

	public class DT_Sensor : DT_AssemblyItem
	{
		public string topic;
		public string sourceGuid;

		public string data;  //place holder for raw data

		public List<DT_Sensor> members;

		public DT_Sensor() : base()
		{
		}

		public override List<DT_Hero> Children()
		{
			if (members == null) return base.Children();
			return members.Select(item => (DT_Hero)item).ToList();
		}

		public DT_Sensor AddMember(DT_Sensor child)
		{
			members ??= new List<DT_Sensor>();
			child.parentGuid = this.guid;
			members.Add(child);
			return child;
		}


		public override DT_Sensor ShallowCopy()
		{
			var result = (DT_Sensor)this.MemberwiseClone();
			result.members = null;

			if (part != null)
				result.part = (DT_Part)part.ShallowCopy();
			result.heroImage = this.heroImage;

			return result;
		}

		public List<DT_Sensor> ShallowMembers()
		{
			var result = members?.Select(obj => obj.ShallowCopy()).ToList();
			return result;
		}

		
	}

}