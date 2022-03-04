namespace IoBTMessage.Models;

[System.Serializable]
public partial class UDTO_Objective : UniqueLocation
{
    public string name { get; set; }
    public string type { get; set; }
    public string symbol { get; set; }
    public string note { get; set; }

    public override string compress(char d = ',')
    {
        return $"{base.compress(d)}{d}{name}{d}{type}{d}{symbol}{d}{note}";
    }

    public override int decompress(string[] data)
    {
        var counter = base.decompress(data);
        name = data[counter++];
        type = data[counter++];
        symbol = data[counter++];
        note = data[counter++];
        return counter;
    }
}

