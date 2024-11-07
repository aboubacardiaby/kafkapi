using Confluent.Kafka;
using Microsoft.Extensions.Options;

public class KafkaProducerService
{
    private readonly IProducer<Null, string> _producer;
    private readonly string _topic;

    public KafkaProducerService(IOptions<KafkaSettings> kafkaSettings)
    {
        var config = new ProducerConfig { BootstrapServers = kafkaSettings.Value.BootstrapServers };
        _producer = new ProducerBuilder<Null, string>(config).Build();
        _topic = kafkaSettings.Value.Topic;
    }

    public async Task ProduceAsync(string message)
    {
        await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
    }
}
