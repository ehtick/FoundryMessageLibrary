namespace IoBTMessage.Models;

public class VirtualSquire
{
    public string PanID { get; set; }
    public string SquadID { get; set; }
    public UDTO_Position CurrentPosition { get; set; }
    public UDTO_ChatMessage LastChatMessage { get; set; }  
    public UDTO_Objective LastObjective { get; set; }  
    public UDTO_Observation LastObservation { get; set; }  
    public UDTO_Biometric LastBiometric { get; set; }  
}

