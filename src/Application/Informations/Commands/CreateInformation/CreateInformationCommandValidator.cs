using CleanArchitecture.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Informations.Commands.CreateInformation
{
    public class CreateInformationCommandValidator : AbstractValidator<CreateInformationCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateInformationCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Sms)
                .NotEmpty()
                .MaximumLength(200)
                .MustAsync(BeUniqueSms)
                    .WithMessage("'{PropertyName}' must be unique.")
                    .WithErrorCode("Unique");
        }

        public async Task<bool> BeUniqueSms(string sms, CancellationToken cancellationToken)
        {
            return await _context.Informations
                .AllAsync(l => l.Sms != sms, cancellationToken);
        }
    }
}
