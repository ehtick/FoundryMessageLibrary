namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Position : Location
{
    public UDTO_Position(): base()
    {
    }
    public UDTO_Position(Location loc): base(loc)
    {
    }
    public override string getUniqueCode()
    {
        return $"{udtoTopic}{sourceGuid}{panID}";
    }

}

