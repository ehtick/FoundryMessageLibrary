namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Command : UDTO_Base
{
    public string targetHashCode { get; set; }
    public string command { get; set; }
    public List<string> args { get; set; }

    public override string compress(char d = ',')
    {
        var arglist = args == null ? "" : String.Join(";", args);
        return $"{base.compress(d)}{d}{this.targetHashCode}{d}{this.command}{d}{arglist}";
    }

    public override int decompress(string[] data)
    {
        var counter = base.decompress(data);
        this.targetHashCode = data[counter++];
        this.command = data[counter++];
        this.args = data[counter++].Split(";").ToList<string>();
        return counter;
    }
}
