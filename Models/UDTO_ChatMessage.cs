namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_ChatMessage : UDTO_Base
{
    public string toUser { get; set; }
    public string fromUser { get; set; }
    public string message { get; set; }

    public UDTO_ChatMessage(): base()
    {
    }
    public override string compress(char d = ',')
    {
        return $"{base.compress(d)}{d}{toUser}{d}{fromUser}{d}{message}";
    }

    public override int decompress(string[] data)
    {
        var count = base.decompress(data);
        toUser = data[count++];
        fromUser = data[count++];
        message = data[count++];
        return count;
    }
}

