namespace CleanArchitecture.Domain.Entities;

public class TodoList : BaseAuditableEntity
{
    public string? Title { get; set; }

    //public Colour Colour { get; set; } = Colour.White;

    public IList<Buyer> Items { get; private set; } = new List<Buyer>();
}
