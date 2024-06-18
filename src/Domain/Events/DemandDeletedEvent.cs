using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Events;
public class DemandDeletedEvent : BaseEvent
{
    public DemandDeletedEvent(Demand instr)
    {
        Instr = instr;
    }

    public Demand Instr { get; }
}

