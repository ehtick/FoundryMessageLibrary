using System.Collections.Generic;

namespace DTARServer.Models
{

	[System.Serializable]
	public class DT_ControlNumbers
	{
		public Dictionary<string,string> lookup;

#if !UNITY
		public DT_ControlNumbers() : base()
		{
		}
		public void Establish(string key, string value)
		{
			lookup ??= new Dictionary<string, string>();
			lookup[key] = value;
		}
		public string Find(string key)
		{
			if ( lookup?.TryGetValue(key, out string value) == true ) return value;
			return null;
		}

#endif
	}
}