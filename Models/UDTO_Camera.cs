namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Camera : UDTO_Base
{
    public string type { get; set; }
    public string name { get; set; }
    public string active { get; set; }
    public string codec { get; set; }
    public string url { get; set; }

    public UDTO_Camera():base()
    {
    }

    public override string compress(char d = ',')
    {
        return $"{base.compress(d)}{d}{this.name}{d}{this.type}{d}{this.active}{d}{this.codec}{d}{this.url}";
    }

    public override int decompress(string[] data)
    {
        var counter = base.decompress(data);
        this.name = data[counter++];
        this.type = data[counter++];
        this.active = data[counter++];
        this.codec = data[counter++];
        this.url = data[counter++];
        return counter;
    }

    public override string getUniqueCode()
    {
        return $"{this.udtoTopic}{this.sourceGuid}{this.panID}{this.name}{this.type}{this.codec}{this.url}";
    }
}
