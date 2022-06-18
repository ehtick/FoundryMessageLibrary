namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_3D : UDTO_Base
{
	public string platformName { get; set; }
	public string uniqueGuid { get; set; }
	public string type { get; set; }
	public string name { get; set; }

	public bool isDelete()
	{
		return this.type == "Command:DELETE" ? true : false;
	}

	public override string compress(char d = ',')
	{
		return $"{base.compress(d)}{d}{platformName}{d}{uniqueGuid}{d}{type}{d}{name}{d}";
	}

	public override int decompress(string[] inputData)
	{
		var counter = base.decompress(inputData);

		platformName = inputData[counter++];
		uniqueGuid = inputData[counter++];
		type = inputData[counter++];
		name = inputData[counter++];
		return counter;
	}

}

