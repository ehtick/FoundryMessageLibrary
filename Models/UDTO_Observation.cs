namespace IoBTMessage.Models;

[System.Serializable]
public partial class UDTO_Observation : UniqueLocation
{
	public string target;
	public double range;

#if !UNITY
	public override string compress(char d = ',')
    {
        return $"{base.compress(d)}{d}{target}{d}{range}";
    }

    public override int decompress(string[] data)
    {
        var counter = base.decompress(data);
        target = data[counter++];
        range = IoBTMath.toDouble(data[counter++]);
        return counter;
    }
#endif
}

