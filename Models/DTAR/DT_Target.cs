using System;
using System.Collections.Generic;
using System.Linq;
using IoBTMessage.Extensions;


namespace IoBTMessage.Models
{

	public class DT_TargetLink: DT_Base
	{
		public string sourceGuid;
		public string sinkGuid;

		public DT_TargetLink()
		{
			this.type = "DT_TargetLink";
		}

		public DT_TargetLink Link(DT_Target from, DT_Target to)
		{
			this.sourceGuid = from.guid;
			this.sinkGuid = to.guid;
			this.name = from.controlNumber + " -> " + to.controlNumber;
			this.type = "DT_TargetLink";
			return this;
		}

	}

	public class DT_Target : DT_Searchable
	{
		public string controlNumber;
		public string targetType;
		public string sourceType;
		public DT_Part part;
		public DT_HeroReference heroReference;
		public List<DT_Thread> threads;


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



	}
}