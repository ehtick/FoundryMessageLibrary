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

	public UDTO_Relationship Build(string source, string relationship, string target)
	{
		this.source = source;
		this.relationship = relationship;
		this.sink.Add(target);
		return this;
	}

	public UDTO_Relationship Relate(string target)
	{
		this.sink.Add(target);
		return this;
	}

	public UDTO_Relationship Unrelate(string target)
	{
		this.sink.Remove(target);
		return this;
	}

	public override UDTO_3D CopyFrom(UDTO_3D obj)
	{
		base.CopyFrom(obj);
		return this;
	}

}

