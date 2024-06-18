using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<Domain.Entities.Buyer> TodoItems { get; }
    DbSet<Demand> Demands { get; }

    DbSet<Information> Informations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
