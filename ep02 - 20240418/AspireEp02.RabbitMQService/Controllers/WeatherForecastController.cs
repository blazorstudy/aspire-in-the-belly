using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace AspireEp02.RabbitMQService.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IConnection _connection;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IConnection connection)
    {
        _logger = logger;
        _connection = connection;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        using var channel = _connection.CreateModel();

        channel.QueueDeclare(queue: "aspire");
        channel.BasicPublish(
            exchange: string.Empty,
            routingKey: "hello",
            basicProperties: null,
            body: Encoding.UTF8.GetBytes("Hello Aspire!"));

        _logger.Log(LogLevel.Information, "Publish success!");

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
