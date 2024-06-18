using CleanArchitecture.Application.Buyer.Commands.CreateBuyer;
using CleanArchitecture.Application.Buyer.Queries.GetUserDemandAllQuery;
using CleanArchitecture.Application.Buyer.Queries.GetUserDemandQuery;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Mappings
{
  
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Demand , DemandVm>();
            CreateMap<Information ,InformationVm>().ConstructUsing(i => new InformationVm
            {
                SendId = i.SendId,
                Sms = i.Sms,
                Email = i.Email,
                PushNotifation = i.PushNotifation,
               
            });

            CreateMap<DemandVm, Demand>();
            CreateMap<InformationVm, Information>();

            CreateMap<CreateBuyerCommand, Demand>();
        }
    }
}
