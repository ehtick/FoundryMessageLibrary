namespace DTARServer.Models;


[System.Serializable]
public class DT_Component : DT_Hero
{
	public string serialNo;
	public string url;

#if !UNITY
	public DT_Component() : base()
    {
    }
#endif
}






