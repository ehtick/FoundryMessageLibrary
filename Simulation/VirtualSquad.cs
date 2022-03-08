namespace IoBTMessage.Models;

public class VirtualSquad
{
    public string SquadID { get; set; }

    public Dictionary<string,VirtualSquire> members { get; set; } = new Dictionary<string,VirtualSquire>();


    public VirtualSquire EstablishVirtualSquire(string panID)
    {

        VirtualSquire found;
        if (members.TryGetValue(panID, out found) == false)
        {
            found = new VirtualSquire()
            {
                PanID = panID,
            };
            members.Add(panID, found);
        }
        return found;
    }

    public List<VirtualSquire> Squires()
    {
        return members.Values.ToList<VirtualSquire>();
    }
}

