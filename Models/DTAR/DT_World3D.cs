// this is a tool to load/unload knowledge modules that define projects
using System.Collections.Generic;
using System.Linq;



namespace IoBTMessage.Models
{

	public class  DT_World3D : DT_Hero
	{
		public string systemName;
		public List<UDTO_Platform> platforms = new List<UDTO_Platform>();
		public List<UDTO_Body> bodies = new List<UDTO_Body>();
		public List<UDTO_Label> labels = new List<UDTO_Label>();
		public List<UDTO_Relationship> relationships = new List<UDTO_Relationship>();

		public DT_World3D()
		{
		}

		public DT_World3D ShallowCopy()
		{
			var result = (DT_World3D)this.MemberwiseClone();
			result.platforms = null;
			result.bodies = null;
			result.labels = null;
			result.relationships = null;
			result.assetReferences = null;
			result.assetReferences = null;
	

			return result;
		}

		public DT_World3D FlushPlatforms()
		{
			platforms.ForEach(platform => platform.Flush());
			return this;
		}

		public List<UDTO_Platform> FillPlatforms()
		{
			platforms.ForEach(platform => {
				platform.Flush();
				var platformName = platform.platformName;
				foreach (var body in bodies)
				{
					if ( platformName == body.platformName)
						platform.Add<UDTO_Body>(body);
				}
				foreach (var label in labels)
				{
					if ( platformName == label.platformName)
						platform.Add<UDTO_Label>(label);
				}
			});
			return this.platforms;
		}

		public DT_World3D FillWorldFromPlatform(UDTO_Platform platform)
		{
			platforms.Add(platform);
			bodies.AddRange(platform.bodies);
			labels.AddRange(platform.labels);
			relationships.AddRange(platform.relationships);
			return RemoveDuplicates();
		}

		public DT_World3D FillWorldFromWorld(DT_World3D world)
		{
			platforms.AddRange(world.platforms);
			bodies.AddRange(world.bodies);
			labels.AddRange(world.labels);
			relationships.AddRange(world.relationships);
			return RemoveDuplicates();
		}

		public DT_World3D RemoveDuplicates()
		{

			platforms = platforms.DistinctBy(i => i.uniqueGuid).ToList();
			bodies = bodies.DistinctBy(i => i.uniqueGuid).ToList();
			labels = labels.DistinctBy(i => i.uniqueGuid).ToList();
			relationships = relationships.DistinctBy(i => i.uniqueGuid).ToList();

			// platforms = platforms.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			// bodies = bodies.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			// labels = labels.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			// relationships = relationships.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			return this;
		}
	}
}