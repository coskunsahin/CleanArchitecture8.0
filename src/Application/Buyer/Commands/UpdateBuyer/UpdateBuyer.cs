using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Buyer.Commands.UpdateBuyer;

public record UpdateDemandCommand : IRequest
{
    public int DenandId { get; init; }



    public bool Done { get; init; }
}

public class UpdateDemandCommandHandler : IRequestHandler<UpdateDemandCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDemandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateDemandCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Demands
            .FindAsync(new object[] { request.DenandId}, cancellationToken);

        Guard.Against.NotFound(request.DenandId, entity);

       
        entity.Done = request.Done;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
