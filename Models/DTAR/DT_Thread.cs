using System;
using System.Collections.Generic;
using System.Linq;
using IoBTMessage.Extensions;


namespace IoBTMessage.Models
{
	public class DT_Thread : DT_Searchable
	{
		public string sheetname { get; set; }
		public string thread { get; set; }
		public string resDes { get; set; }
		public string controlNumber { get; set; }
		public string serialNumber { get; set; }
		public string version { get; set; }

		private DT_HeroReference heroReference;



		public DT_Hero GetSource() 
		{
			if (heroReference == null)
				return null;
			//this should resolve the heroReference to a hero
			var source = heroReference.hero;
			return source;
		}
		public DT_Hero SetSource(DT_Hero item) 
		{
			heroReference ??= new DT_HeroReference();
			heroReference.hero = item;
			return item;
		}
 	}

}