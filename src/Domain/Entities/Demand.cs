using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Demand:BaseAuditableEntity
{

    [Key]
    public int DemandId { get; set; }

    public string? Name { get; set; }
    public DateTime Date { get; set; }
    public int Unit { get; set; }
    public double Amount { get; set; }
    public double Balance { get; set; }
    [ForeignKey("Information")]
    public int SendId { get; set; }
    // public bool Done { get; set; }



    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value && !_done)
            {
                AddDomainEvent(new DemandCompletedEvent(this));
            }

            _done = value;
        }
    }

    public Information? Informations { get; set; }
}
