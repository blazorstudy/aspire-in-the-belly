using System.Text.Json;

using AspireInTheBelly.WorkerService.Models;

using Azure.Data.Tables;
using Azure.Storage.Queues;

namespace AspireInTheBelly.WorkerService;

public class Worker(QueueServiceClient queueServiceClient, TableServiceClient tableServiceClient, ILogger<Worker> logger) : BackgroundService
{
    private readonly QueueClient _queueClient = queueServiceClient.GetQueueClient("attendees") ?? throw new ArgumentNullException(nameof(queueServiceClient));
    private readonly TableClient _tableClient = tableServiceClient.GetTableClient("events") ?? throw new ArgumentNullException(nameof(tableServiceClient));
    private readonly ILogger<Worker> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await this.EnsureClientsExistAsync();

        while (!stoppingToken.IsCancellationRequested)
        {
            var response = await this._queueClient.ReceiveMessagesAsync();
            response.Value.ToList().ForEach(async message =>
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Processing message: {message}", message.MessageText);
                }

                var attendee = JsonSerializer.Deserialize<Attendee>(message.MessageText);

                await this._tableClient.AddEntityAsync(new TableEntity("awesome-event", message.MessageId)
                {
                    { "Name", attendee.Name },
                    { "Email", attendee.Email },
                    { "Mobile", attendee.Mobile }
                });

                await this._queueClient.DeleteMessageAsync(message.MessageId, message.PopReceipt);
            });

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }

    private async Task EnsureClientsExistAsync()
    {
        await this._queueClient.CreateIfNotExistsAsync();
        await this._tableClient.CreateIfNotExistsAsync();
    }
}
