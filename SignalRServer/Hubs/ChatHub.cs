using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs;

public class ChatHub : Hub<IChatClient>
{
    private readonly ILogger<ChatHub> _logger;

    public ChatHub(ILogger<ChatHub> logger) => _logger = logger;

    public async Task SendMessage(ChatMessage message)
    {
        _logger.LogInformation($"User: {message.User}, Message: {message.Message}");
        await Clients.All.ReceiveMessage(message);
    }
}

public interface IChatClient
{
    Task ReceiveMessage(ChatMessage message);
}

public class ChatMessage
{
    public string User { get; set; }
    public string Message { get; set; }
}