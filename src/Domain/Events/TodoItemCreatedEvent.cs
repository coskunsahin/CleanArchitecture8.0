namespace CleanArchitecture.Domain.Events;

public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(Buyer item)
    {
        Item = item;
    }

    public Buyer Item { get; }
}
