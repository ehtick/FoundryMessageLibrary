using System.Collections.Generic;

namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_ControlNumbers
	{
		public Dictionary<string,object> lookup;

#if !UNITY
		public DT_ControlNumbers() : base()
		{
		}
		public void Establish(string key, object value)
		{
			lookup ??= new Dictionary<string, object>();
			lookup[key] = value;
		}
		public object Find(string key)
		{
			if ( lookup?.TryGetValue(key, out object value) == true ) return value;
			return null;
		}

#endif
	}
}