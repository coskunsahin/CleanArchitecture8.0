using CleanArchitecture.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Buyers.EventHandlers;

public class DemandCompletedEventHandler : INotificationHandler<DemandCompletedEvent>
{
    private readonly ILogger<DemandCompletedEventHandler> _logger;

    public DemandCompletedEventHandler(ILogger<DemandCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DemandCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
