using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Buyer.Commands.DeleteBuyer
{
    public record DeleteBuyerCommand(int Id) : IRequest;

    public class DeleteBuyerCommandHandler : IRequestHandler<DeleteBuyerCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<DeleteBuyerCommandHandler> _logger;
        public DeleteBuyerCommandHandler(IApplicationDbContext context, ILogger<DeleteBuyerCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(DeleteBuyerCommand request, CancellationToken cancellationToken)
        {
            try
            {

                await Task.Delay(3000, cancellationToken);
                _logger.LogError("executing long running code..");
                var entity = await _context.Demands
                    .FindAsync(new object[] { request.Id }, cancellationToken);

                Guard.Against.NotFound(request.Id, entity);

                _context.Demands.Remove(entity);

                entity.AddDomainEvent(new DemandDeletedEvent(entity));

                //wait _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                _logger.LogError("Cancelled  task");
                //return BadRequest();
            }
        }

    }




}
