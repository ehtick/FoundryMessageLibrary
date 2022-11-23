namespace IoBTMessage.Models
{
    [System.Serializable]
	public class DT_Error : DT_StatusText
	{

#if !UNITY
		public DT_Error() : base()
		{
		}
#endif
	}
}
