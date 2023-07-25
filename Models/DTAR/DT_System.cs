using System.Collections.Generic;
using System.Linq;
using IoBTMessage.Extensions;

namespace IoBTMessage.Models
{



	[System.Serializable]
	public class DT_System : DT_Hero, ISystem
	{

		public List<DT_Thread> threads;
		public List<DT_Target> targets;
		public List<DT_TargetLink> links;

		public DT_System()
		{
		}

		public DT_System ShallowCopy()
		{
			var result = (DT_System)this.MemberwiseClone();
			result.threads = null;
			result.targets = null;
			result.links = null;
			result.assetReferences = null;
			result.heroImage = this.heroImage;

			return result;
		}

		public void Merge(DT_System obj)
		{
			foreach (var target in obj.Targets()) 
			{ 
				AddTarget(target);
			}
			foreach (var link in obj.Links())
			{
				AddLink(link);
			}
		}

		public void Flush()
		{
			targets = new();
			links = new();
		}
		public List<DT_Target> AddTarget(DT_Target target)
		{
			targets ??= new List<DT_Target>();
			if (target != null)
				targets.Add(target);

			return targets;
		}
		public List<DT_Target> RemoveUnlinkedTargets()
		{
			var unlinked = Targets().Where(t => t.linkCount == 0).ToList();
			foreach (var item in unlinked)
			{
				$"Unlinked: {item.GetKey()}".WriteLine(System.ConsoleColor.DarkYellow);
			} 
			var linked = Targets().Where(t => t.linkCount > 0).ToList();
			foreach (var item in linked)
			{
				$"Linked: {item.GetKey()} {item.linkCount}".WriteLine(System.ConsoleColor.DarkGreen);				
			} 

			foreach (var item in  Links())
			{
				$"Edge: {item.title}".WriteLine(System.ConsoleColor.Green);				
			}
			targets = linked;
			return targets;
		}

		public List<DT_Target> Targets()
		{
			targets ??= new List<DT_Target>();
			return targets;
		}
		public List<DT_TargetLink> Links()
		{
			links ??= new List<DT_TargetLink>();
			return links;
		}
		public List<DT_Thread> Threads()
		{
			threads ??= new List<DT_Thread>();
			return threads;
		}
		public DT_Target FindTarget(string key)
		{
			var found = targets?.FirstOrDefault(t => t.GetKey().Matches(key));
			return found;
		}

		public DT_Target FindTarget(string type, string controlNumber)
		{
			var found  = targets?.FirstOrDefault(t => t.targetType.Matches(type)  && t.controlNumber.Matches(controlNumber));
			return found;
		}
		public (DT_Target, DT_Target)  ResolveLink(DT_TargetLink link)
		{
			var source = targets?.FirstOrDefault(t => link.sourceGuid.Matches(t.guid));
			var sink = targets?.FirstOrDefault(t => link.sinkGuid.Matches(t.guid));
			return (source, sink);
		}

		public List<DT_TargetLink> AddLink(DT_TargetLink link)
		{
			links ??= new List<DT_TargetLink>();
			if (link != null)
				links.Add(link);

			return links;
		}

		public List<DT_Thread> AddThread(DT_Thread link)
		{
			threads ??= new List<DT_Thread>();
			if (link != null)
				threads.Add(link);

			return threads;
		}


	}
}


