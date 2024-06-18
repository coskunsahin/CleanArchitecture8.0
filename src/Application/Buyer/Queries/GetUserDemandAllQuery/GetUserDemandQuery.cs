using CleanArchitecture.Application.Buyer.Queries.GetUserDemandQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Buyer.Queries.GetUserDemandQuery
{
    public class GetUserDemandQuery : IRequest<IList<DemandVm>>
    {
        public string? User { get; set; }
    }
}
