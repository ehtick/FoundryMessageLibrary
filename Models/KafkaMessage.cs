namespace IoBTMessage.Models;

[System.Serializable]
public class KafkaMessage {
    public string topic { get; set; }
    public object data { get; set; }
}
