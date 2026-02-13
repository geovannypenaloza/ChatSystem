using Microsoft.AspNetCore.SignalR;

namespace ChatSystem.Hubs;

public class ChatHub: Hub
{
    private readonly ILogger<ChatHub> _logger;
    private  readonly IHubContext<ChatHub> _hubContext;
    public ChatHub(ILogger<ChatHub> logger, IHubContext<ChatHub> hubContext)
    {
        _logger = logger;
        _hubContext = hubContext;
    }
    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"Hub connected: {Context.ConnectionId}");
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation($"Hub disconnected: {Context.ConnectionId}");
        return base.OnDisconnectedAsync(exception);
    }

    public async Task GeneralSend(string message)
    {
        _logger.LogWarning($"mensaje entre al metodo: {message}");
        await _hubContext.Clients.All.SendAsync("OnGeneralSend", message);
    }
}