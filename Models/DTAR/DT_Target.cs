using System;
using System.Collections.Generic;
using System.Linq;
using IoBTMessage.Extensions;


namespace IoBTMessage.Models
{


	public class DT_Target : DT_Searchable
	{
		public string controlNumber;
		public string targetType;
		public DT_Part part;
		public DT_HeroReference heroReference;
		public List<DT_Thread> threads;
		public List<string> targetGUIDs;
		private List<DT_Target> targets;  //might need a ref to advoid circular json


		public DT_Target()
		{
			part = new DT_Part();
		}
		public DT_Part CopyFrom(DT_Part source)
		{
			source.CopyNonNullFields(this.part);
			return this.part;
		}

		public List<DT_Thread> AddThread(DT_Thread thread)
		{
			threads ??= new List<DT_Thread>();
			if (thread != null)
				threads.Add(thread);

			return threads;
		}

		public List<DT_Target> AddTarget(DT_Target target)
		{
			targets ??= new List<DT_Target>();
			if (target != null)
				targets.Add(target);

			return targets;
		}

	}
}