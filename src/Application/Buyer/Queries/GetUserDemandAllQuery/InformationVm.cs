using CleanArchitecture.Application.Buyer.Queries.GetUserDemandQuery;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Buyer.Queries.GetUserDemandAllQuery
{
   

    public class InformationVm
    {
        public InformationVm()
        {
            this.DemandVms = new List<DemandVm>();
        }

        public int SendId { get; set; }
        public string? Sms { get; set; }
        public string? Email { get; set; }

        public string? PushNotifation { get; set; }
        public IList<DemandVm> DemandVms { get; set; } 
    }

}
