using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Informations.Queries.GetLoggerQueryId
{
    public record GetLoggerQueryIdPaginationQuery : IRequest<PaginatedList<DemandBriefDto>>
    {
         
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
      
        public String? yes { get ; init; }  
    }

    public class GetLoggerQueryIdPaginationQueryHandler : IRequestHandler<GetLoggerQueryIdPaginationQuery, PaginatedList<DemandBriefDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
    

        public GetLoggerQueryIdPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
           
        }

        public async Task<PaginatedList<DemandBriefDto>> Handle(GetLoggerQueryIdPaginationQuery request, CancellationToken cancellationToken)
        {
           
            return await _context.Informations.Include(x=>x.Demands)
                .Where(x => x.Sms == request.yes )
                .OrderBy(x => x.SendId)
                .ProjectTo<DemandBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
            
        }
    }

}
