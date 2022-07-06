using System;
using System.Collections.Generic;
using System.Linq;


namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Decision : UDTO_Base
{
	public string targetGuid;
	public string command;
	public string message;
}
