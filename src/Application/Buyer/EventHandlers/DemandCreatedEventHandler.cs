using CleanArchitecture.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Buyers.EventHandlers;

public class DemandCreatedEventHandler : INotificationHandler<DemantCreatedEvent>
{
    private readonly ILogger<DemandCreatedEventHandler> _logger;

    public DemandCreatedEventHandler(ILogger<DemandCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DemantCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
