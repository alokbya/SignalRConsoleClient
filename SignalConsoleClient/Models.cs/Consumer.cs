using Microsoft.AspNetCore.SignalR.Client;

namespace SignalConsoleClient.Models.cs;

public class Consumer : IAsyncDisposable
{
    private HubConnection _hubConnection;
    private List<BaseMessage> _messages;
    
    public Consumer()
    {
        this.Name = "Console-Client";
        _hubConnection = new HubConnectionBuilder()
            .WithUrl($"http://localhost:5172/chathub")
            .WithAutomaticReconnect()
            .Build();

        _hubConnection.On<BaseMessage>("ReceiveMessage", (message) =>
        {
            if (message is not null)
            {
                _messages.Add(message);
            }
        });
        
        _messages = new List<BaseMessage>();

        _hubConnection.StartAsync();
    }

    public async Task Send()
    {
        if (_hubConnection is not null)
        {
            var input = Console.ReadLine();
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                await _hubConnection.SendAsync("SendMessage", new BaseMessage(Guid.NewGuid(), this.Name, input));
            }
        }
    }
    public List<BaseMessage> Messages { get => _messages; }
    public string Name { get; }
    
    public async ValueTask DisposeAsync()
    {
        if (_hubConnection is not null)
        {
            await _hubConnection.DisposeAsync();
        }
    }
}