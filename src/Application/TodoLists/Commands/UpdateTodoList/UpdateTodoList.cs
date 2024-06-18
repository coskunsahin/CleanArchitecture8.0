//using CleanArchitecture.Application.Common.Interfaces;

//namespace CleanArchitecture.Application.TodoLists.Commands.UpdateTodoList;

//public record UpdateTodoListCommand : IRequest
//{
//    public int DemandId { get; init; }

//    public string? Title { get; init; }
//    public bool Done {  get; init; }
//}

//public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
//{
//    private readonly IApplicationDbContext _context;

//    public UpdateTodoListCommandHandler(IApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
//    {
//        var entity = await _context.Demands
//            .FindAsync(new object[] { request.DemandId }, cancellationToken);

//        Guard.Against.NotFound(request.DemandId, entity);

//        entity.Done = request.Done;

//        await _context.SaveChangesAsync(cancellationToken);

//    }
//}
