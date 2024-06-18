using CleanArchitecture.Application.Buyer.Queries.GetUserDemandAllQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Buyer.Queries.GetDemandAllQuery
{
    public class GetInfoSe :  IRequest<IList<InformationVm>>
    {
         public string? User {  get; set; }
    }
}
