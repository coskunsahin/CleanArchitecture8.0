using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;

namespace CleanArchitecture.Application.Buyer.Commands.CreateBuyer;


public record CreateBuyerCommand : IRequest<int>
{

    public string? Name { get; init; }

    

    public DateTime Date { get; init; }
    public int Unit { get; init; }
    public double Amount { get; init; }
    public double Balance { get; init; }
    public int SendId { get; init; }
 
}

public class CreateBuyerCommandHandler : IRequestHandler<CreateBuyerCommand, int>
{
    public int a = 1;
    public bool use = false;
    
    private readonly IApplicationDbContext _context;

    public CreateBuyerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBuyerCommand request, CancellationToken cancellationToken)
    {

        Demand entity = new Demand
            {
                Name = request.Name,
                Date = request.Date,
                Unit = request.Unit,
                Amount = request.Amount,
                Balance = request.Balance,
                SendId=request.SendId,
                Done = false,
               
               
            };
        
           
                entity.AddDomainEvent(new DemantCreatedEvent(entity));

                _context.Demands.Add(entity);
                 
                await _context.SaveChangesAsync(cancellationToken);

        
         
        return entity.Id;



            }
        }
  