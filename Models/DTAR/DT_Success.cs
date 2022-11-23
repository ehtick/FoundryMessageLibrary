namespace IoBTMessage.Models
{
    public class DT_Success : DT_StatusText
	{

#if !UNITY
		public DT_Success() : base()
		{
		}
#endif
	}
}
