namespace IoBTMessage.Models
{
    public class DT_Warning : DT_StatusText
	{

#if !UNITY
		public DT_Warning() : base()
		{
		}
#endif
	}
}
