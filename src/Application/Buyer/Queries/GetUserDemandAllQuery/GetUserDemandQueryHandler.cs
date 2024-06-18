using CleanArchitecture.Application.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Buyer.Queries.GetUserDemandQuery;
using Microsoft.Extensions.Logging;
using CleanArchitecture.Application.TodoLists.Queries.GetTodos;


namespace CleanArchitecture.Application.Buyer.Queries.GetUserDemandQuery
{
   
    public class GetUserDemandQueryHandler : IRequestHandler<GetUserDemandQuery, IList<DemandVm>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDemandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<IList<DemandVm>> Handle(GetUserDemandQuery request, CancellationToken cancellationToken)
        {
            var result = new List<DemandVm>();
            var demands = await _context.Demands.Include(x => x.Informations).ToListAsync(cancellationToken);
            if (demands != null)
            {
                result = _mapper.Map<List<DemandVm>>(demands);
            }



            return result;
        }
    }
}