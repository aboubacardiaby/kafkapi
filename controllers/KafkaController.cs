using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class KafkaController : ControllerBase
{
    private readonly KafkaProducerService _producerService;

    public KafkaController(KafkaProducerService producerService)
    {
        _producerService = producerService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] string message)
    {
        await _producerService.ProduceAsync(message);
        return Ok("Message sent to Kafka");
    }
}
