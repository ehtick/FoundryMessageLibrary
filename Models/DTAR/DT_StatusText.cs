namespace IoBTMessage.Models
{
    [System.Serializable]
	public class DT_StatusText : DT_Base
	{
		public string text;
		public object source;

#if !UNITY
		public DT_StatusText() : base()
		{
		}
#endif
	}
}
