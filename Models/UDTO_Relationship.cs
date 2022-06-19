namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Relationship : UDTO_3D
{
	public string relationship { get; set; }
	public string source { get; set; }
	public List<string> sink { get; set; } = new List<string>();

	public UDTO_Relationship() : base()
    {
    }

	public UDTO_Relationship Apply(string source, string relationship, string sink)
	{
		this.source = source;
		this.relationship = relationship;
		this.sink.Add(sink);
		return this;
	}

	public override UDTO_3D CopyFrom(UDTO_3D obj)
	{
		base.CopyFrom(obj);
		return this;
	}

	public override string compress(char d = ',')
    {
		var count = sink.Count;
		var targets = string.Join(d, sink);
		return $"{base.compress(d)}{d}{source}{d}{relationship}{d}{count}{d}{targets}";
    }

    public override int decompress(string[] inputData)
    {
        var counter = base.decompress(inputData);

        source = inputData[counter++];
		relationship = inputData[counter++];
		var count = int.Parse(inputData[counter++]);
        sink = inputData.SubArray(counter, count).ToList();
 
        return counter;
    }
}

