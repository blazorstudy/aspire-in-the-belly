using System.Text.Json;

using AspireInTheBelly.Web.Models;

using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace AspireInTheBelly.Web.Services;

public interface IAttendeeRegistrationService
{
    Task<SendReceipt> RegisterAttendeeAsync(Attendee attendee);
}

public class AttendeeRegistrationService(QueueServiceClient client) : IAttendeeRegistrationService
{
    private readonly QueueClient _client = client.GetQueueClient("attendees") ?? throw new ArgumentNullException(nameof(client));

    public async Task<SendReceipt> RegisterAttendeeAsync(Attendee attendee)
    {
        await this.EnsureQueueClientExistsAsync();

        var serialised = JsonSerializer.Serialize(attendee);

        var response = await this._client.SendMessageAsync(serialised)
                                         .ConfigureAwait(false);

        return response.Value;
    }

    private async Task EnsureQueueClientExistsAsync()
    {
        await this._client.CreateIfNotExistsAsync();
    }
}
