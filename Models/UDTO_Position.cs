namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Position : Location
{
    public override string getUniqueCode()
    {
        return $"{udtoTopic}{sourceGuid}{panID}";
    }
}

