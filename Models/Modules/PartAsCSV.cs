
namespace IoBTMessage.Models;

public class PartAsCSV //  same as DT_Part but not fields
{
    public string structureCode { get; set; }
    public string referenceDesignation { get; set; }
    public string partNumber { get; set; }
    public string serialNumber { get; set; }
    public string revision { get; set; }
    public string guid { get; set; }
    public string name { get; set; }
    public string type { get; set; }
}
