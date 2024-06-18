using CleanArchitecture.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.TodoItems.EventHandlers;

public class DemandsCompletedEventHandler : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<DemandsCompletedEventHandler> _logger;

    public DemandsCompletedEventHandler(ILogger<DemandsCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
