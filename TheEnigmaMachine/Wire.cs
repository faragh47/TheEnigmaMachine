using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEnigmaMachine.Entities;
using TheEnigmaMachine.Enums;

namespace TheEnigmaMachine
{
    public record Wire
    {
        public Wire(Punch destination, Punch origin)
        {
            Origin = origin;
            Destination = destination;
            if (Origin is not null && Destination is not null)
                Status = WireStatus.Complete;
        }
        public Punch Origin { get; set; }
        public Punch Destination { get; set; }
        public WireStatus Status { get; set; } = WireStatus.InComplete;
    }
}
