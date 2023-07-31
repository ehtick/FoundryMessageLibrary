using System;
using System.Collections.Generic;
using System.Linq;
using IoBTMessage.Extensions;


namespace IoBTMessage.Models
{

	public class DT_TargetLink: DT_Searchable
	{
		public string sourceGuid;
		public string sinkGuid;

		public DT_TargetLink()
		{
			this.type = "DT_TargetLink";
		}

		public static DT_TargetLink Create(DT_Target from, DT_Target to)
		{
			var link = new DT_TargetLink();
			return link.Link(from, to);
		}

		public DT_TargetLink Link(DT_Target from, DT_Target to)
		{
			from.linkCount++;
			to.linkCount++;
			
			this.sourceGuid = from.guid;
			this.sinkGuid = to.guid;
			this.name = $"{from.address} -- {to.address}";
			this.title = $"{from.GetKey()} == {to.GetKey()}";
			this.type = "DT_TargetLink";
			return this;
		}

	}

	public class DT_Target : DT_Searchable
	{
		public string address;
		public string domain;
		public int linkCount;
		
		public DT_Part part;
		public DT_HeroReference heroReference;
		public DT_AssetFile asset;
		public List<string> threads;


		public DT_Target()
		{
			part = new DT_Part();
			linkCount = 0;
		}
		public DT_Part CopyFrom(DT_Part source)
		{
			source.CopyNonNullFields(this.part);
			return this.part;
		}

		public string GetKey()
		{
			return $"{domain}:{address}";
		}

		public List<string> AddThread(string thread)
		{
			threads ??= new List<string>();
			if (thread != null)
				threads.Add(thread);

			return threads;
		}



	}
}