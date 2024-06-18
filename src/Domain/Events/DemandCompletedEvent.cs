using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Events;
public class DemandCompletedEvent : BaseEvent
{

    public DemandCompletedEvent(Demand inst)
    {
        Inst = inst;
    }

    public Demand Inst { get; }
}

