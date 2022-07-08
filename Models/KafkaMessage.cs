namespace IoBTMessage.Models;

[System.Serializable]
public class KafkaMessage {
	public string topic;
	public object data;
}
