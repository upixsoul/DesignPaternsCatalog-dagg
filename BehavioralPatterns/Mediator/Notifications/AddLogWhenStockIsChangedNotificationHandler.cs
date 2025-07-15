using MediatR;
using Microsoft.Extensions.Logging;

namespace BehavioralPatterns.Mediator.Notifications
{
    public sealed record StockChangedNotification(string Name) : INotification;

    public class AddLogWhenStockIsChangedNotificationHandler(ILogger<AddLogWhenStockIsChangedNotificationHandler> logger) : INotificationHandler<StockChangedNotification>
    {
        public Task Handle(StockChangedNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Stock is updated. Product Name: {Name}.", notification.Name);

            return Task.CompletedTask;
        }
    }
}
