namespace CleanArchitecture.Domain.Events;

public class TodoItemDeletedEvent : BaseEvent
{
    public TodoItemDeletedEvent(Buyer item)
    {
        Item = item;
    }

    public Buyer Item { get; }
}
