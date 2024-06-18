namespace CleanArchitecture.Domain.Events;

public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemCompletedEvent(Buyer item)
    {
        Item = item;
    }

    public Buyer Item { get; }
}
