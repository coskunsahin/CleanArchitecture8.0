using CleanArchitecture.Application.Buyer.Queries.GetUserDemandAllQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Buyer.Queries.GetUserDemandQuery
{
    public class DemandVm
    {

        public int DemandId { get; init; }

        public string? Name { get; init; }
        public DateTime Date { get; init; }
        public int Unit { get; init; }
        public double Amount { get; init; }
        public double Balance { get; init; }
        public int SendId { get; init; }

        public bool Done { get; init; }
        
    }
}
