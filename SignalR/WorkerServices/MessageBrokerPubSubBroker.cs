using System.Reflection;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;

namespace SignalR.WorkerServices
{
    public sealed class MessageBrokerPubSubBroker : BackgroundService
    {
        private readonly IHubContext<MessageBrokerHub> _hubContext;

        public MessageBrokerPubSubBroker(IHubContext<MessageBrokerHub> hubContext)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
                var eventMessage = new EventMessage($"Id_{Guid.NewGuid()}", $"Title_{Guid.NewGuid()}", DateTime.UtcNow);
                await _hubContext.Clients.All.SendAsync("onMessageReceived", eventMessage,stoppingToken);
            }
        }
    }
}
