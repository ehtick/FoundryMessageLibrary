// this is a tool to load/unload knowledge modules that define projects
using System;
using System.Collections.Generic;
using System.Linq;
using FoundryRulesAndUnits.Extensions;
using FoundryRulesAndUnits.Models;


namespace IoBTMessage.Models
{


	public class UDTO_World : UDTO_3D, ISystem
	{
		public string systemName;
		public string lengthUnits = "m";
		public string angleUnits = "r";

		public List<UDTO_Body> bodies = new();
		public List<UDTO_Pathway> pathways = new();
		public List<UDTO_Label> labels = new();
		public List<UDTO_Relationship> relationships = new();

		public UDTO_World() : base()
		{
		}

		private List<T> FindLookup<T>() where T : UDTO_3D
		{
			if (typeof(T) == typeof(UDTO_Body)) return bodies as List<T>;
			if (typeof(T) == typeof(UDTO_Label)) return labels as List<T>;
			if (typeof(T) == typeof(UDTO_Pathway)) return pathways as List<T>;
			if (typeof(T) == typeof(UDTO_Relationship)) return relationships as List<T>;

			return null;
		}
		public T FindOrCreate<T>(string name, bool create = false) where T : UDTO_3D
		{
			var list = FindLookup<T>();
			var found = list?.FirstOrDefault(item => item.name.Matches(name));
			if (found == null && create)
			{
				found = CreateItem<T>(name);
				list?.Add(found);
			}
			return found!;
		}

		public T CreateUsing<T>(string name, string guid = "") where T : UDTO_3D
		{
			var found = FindOrCreate<T>(name, true);
			if (!string.IsNullOrEmpty(guid))
			{
				found!.uniqueGuid = guid;
			}
			return found!;
		}


		private T CreateItem<T>(string name) where T : UDTO_3D
		{
			var found = Activator.CreateInstance<T>() as T;
			found.name = name;
			found.panID = panID;
			found.uniqueGuid = Guid.NewGuid().ToString();
			return found;
		}





		public UDTO_World AsShallowCopy()
		{
			var result = (UDTO_World)this.MemberwiseClone();
			result.Flush();
			return result;
		}



		public UDTO_World Flush()
		{
			bodies.Clear();
			pathways.Clear();
			labels.Clear();
			relationships.Clear();
			return this;
		}



		public UDTO_World FillWorldFromWorld(UDTO_World world)
		{
			bodies.AddRange(world.bodies);
			pathways.AddRange(world.pathways);
			labels.AddRange(world.labels);
			relationships.AddRange(world.relationships);
			return RemoveDuplicates();
		}

		public UDTO_World RemoveDuplicates()
		{
			bodies = bodies.DistinctBy(i => i.uniqueGuid).ToList();
			pathways = pathways.DistinctBy(i => i.uniqueGuid).ToList();
			labels = labels.DistinctBy(i => i.uniqueGuid).ToList();
			relationships = relationships.DistinctBy(i => i.uniqueGuid).ToList();

			// platforms = platforms.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			// bodies = bodies.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			// labels = labels.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			// relationships = relationships.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			return this;
		}


		public T CreateUsingDTBASE<T>(DT_Base obj) where T : UDTO_3D
		{
			return CreateUsing<T>(obj.name, obj.guid);
		}



		public UDTO_Body CreateBoundingBox(DT_Base obj, double width = 1.0, double height = 1.0, double depth = 1.0)
		{
			var result = CreateUsingDTBASE<UDTO_Body>(obj);
			return result.EstablishBox(width, height, depth);
		}


	}
}