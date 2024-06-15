using System.Text.Json;

using AspireInTheBelly.Web.Models;

using Azure.Data.Tables;

namespace AspireInTheBelly.Web.Services;

public interface IAttendeeViewService
{
    Task<List<Attendee>> GetAttendeesAsync();
}

public class AttendeeViewService(TableServiceClient client) : IAttendeeViewService
{
    private readonly TableClient _client = client.GetTableClient("events") ?? throw new ArgumentNullException(nameof(client));

    public async Task<List<Attendee>> GetAttendeesAsync()
    {
        await this.EnsureQueueClientExistsAsync();

        var pages = this._client.QueryAsync<TableEntity>();
        var attendees = new List<Attendee>();
        await foreach (var page in pages.AsPages())
        {
            attendees.AddRange(page.Values.Select(p => new Attendee(p["Name"].ToString(), p["Email"].ToString(), p["Mobile"].ToString())));
        }

        return attendees;
    }

    private async Task EnsureQueueClientExistsAsync()
    {
        await this._client.CreateIfNotExistsAsync();
    }
}
