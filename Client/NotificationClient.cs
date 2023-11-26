using Microsoft.AspNetCore.SignalR.Client;

namespace Client;

public class NotificationClient
{
    private readonly HubConnection _hubConnection;

    public NotificationClient(string hubUrl)
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(hubUrl)
            .Build();

        _hubConnection.On<string>("ReceiveNotification", (message) =>
        {
            Console.WriteLine($"Received notification: {message}");
        });
    }

    public async void Start()
    {
        await _hubConnection.StartAsync();
        Console.WriteLine("Connected to the notification hub.");
    }

    public async void Stop()
    {
        await _hubConnection.StopAsync();
        Console.WriteLine("Disconnected from the notification hub.");
    }
}
