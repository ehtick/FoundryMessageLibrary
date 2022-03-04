using System;
using System.Collections.Generic;
using System.Linq;


namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Decision : UDTO_Base
{
    public string targetGuid { get; set; }
    public string command { get; set; }
    public string message { get; set; }
}
