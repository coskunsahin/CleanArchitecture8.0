using CleanArchitecture.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Informations.Commands.CreateInformation
{
    public record CreateInformationCommand : IRequest<int>
    {
     
        public string? Sms { get; init; }
        public string? Email { get; init; }
   
        public string? PushNotifation { get; init; }


    }

    public class CreateInformationCommandHandler : IRequestHandler<CreateInformationCommand, int>
    {
        private readonly IApplicationDbContext _context;
      //  private readonly ILogger<CreateInformationCommandHandler> _logger;

        public CreateInformationCommandHandler(IApplicationDbContext context )
        {
            _context = context;
             //_logger = logger;
        }
        public async Task<int> Handle(CreateInformationCommand request, CancellationToken cancellationToken)
        { 
            var entity = new Information();
            
            entity.Sms = request.Sms;
            entity.Email = request.Email;
           
            entity.PushNotifation = request.PushNotifation;
            _context.Informations.Add(entity);
         
            await _context.SaveChangesAsync(cancellationToken);
            //_logger.LogInformation("This is a log message. This is an object: {Sms}", new { Sms = "yes" });
            //_logger.LogInformation("This is a log message. This is an object: {Email}", new { Sms = "yes" });
            //_logger.LogInformation("This is a log message. This is an object: {PushNotifation}", new { Sms = "yes" });

            return entity.Id;
            
            
        }
    }
}

 