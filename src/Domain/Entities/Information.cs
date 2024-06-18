using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchitecture.Domain.Entities;
public class Information : BaseAuditableEntity
{
    public Information()
    {
        this.Demands = new List<Demand>();
    }
    [Key]
    public int SendId { get; set; }
    public string? Sms { get; set; }
    public string? Email { get; set; }

    public string? PushNotifation { get; set; }
    public IList<Demand> Demands { get; set; }= new List<Demand>(); 

  
    

}

