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


[System.Serializable]
public class DT_ComponentReference : DT_Base
{
	public string componentGuid;
	public DT_Component component;

#if !UNITY
	public DT_ComponentReference() : base()
	{
	}
#endif
}


