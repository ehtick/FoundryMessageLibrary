namespace DTARServer.Models;


[System.Serializable]
public class DT_Component : DT_Hero
{
	public string serialNumber;
	public string partID;
	public string hsc { get; set; }
	public string structureLevel { get; set; }

#if !UNITY
	public DT_Component() : base()
    {

    }
	public string serialName() {
		return $"{serialNumber}@{partID}";
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


