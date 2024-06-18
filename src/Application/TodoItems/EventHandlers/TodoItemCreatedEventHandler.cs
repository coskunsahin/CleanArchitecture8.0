using CleanArchitecture.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.TodoItems.EventHandlers;

public class DemandsCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<DemandsCreatedEventHandler> _logger;

    public DemandsCreatedEventHandler(ILogger<DemandsCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
