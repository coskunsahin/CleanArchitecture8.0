using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Events;
public class DemantCreatedEvent : BaseEvent
{
    public DemantCreatedEvent(Demand instr)
    {
        Instr = instr;
    }

    public Demand Instr { get; }
}

