namespace DTARServer.Models;

//(B)::used for visualization in higher level assemblies (where SCV fits within the Fuel Delivery Assy, then in overall Mk48 AB/TC & Fuel Tank)
[System.Serializable]
public class DT_CAD : DT_Document
{
    public Dictionary<string, string> formats;
    public DT_CAD () {
        formats = new Dictionary<string, string>();
    }

}


