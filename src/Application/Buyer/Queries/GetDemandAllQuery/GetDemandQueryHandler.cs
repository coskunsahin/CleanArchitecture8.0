using CleanArchitecture.Application.Buyer.Queries.GetUserDemandAllQuery;
using CleanArchitecture.Application.Buyer.Queries.GetUserDemandQuery;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Buyer.Queries.GetDemandAllQuery
{
    public class GetDemandQueryHandler : IRequestHandler<GetInfoSe, IList<InformationVm>>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDemandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<InformationVm>> Handle(GetInfoSe request, CancellationToken cancellationToken)
        {



            var vm = await _context.Informations.Include(x => x.Demands).Where(x=>x.SendId==x.Id).Select(x => new InformationVm
            {
                PushNotifation = x.PushNotifation,
                SendId = x.SendId,
                Sms = x.Sms,
                Email = x.Email,

                DemandVms = x.Demands.Select(x => new DemandVm{ SendId = x.SendId, DemandId = x.DemandId, Name = x.Name }).ToList(),

            }).OrderByDescending(x=>x.SendId).ToListAsync(cancellationToken: cancellationToken);

            //result = _mapper.Map<List<InformationVm>>(Informations);
           
            return vm;
        }

         
    }
}
