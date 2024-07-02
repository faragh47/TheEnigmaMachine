using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEnigmaMachine.Enums;
using TheEnigmaMachine.Interfaces;

namespace TheEnigmaMachine.Entities
{
    public class WireStorage : IWireStorage
    {
        private const int MAX_WIRE_COUNT = 10;
        public List<Wire> Wires { get; set; }
        public WireStorageStatus Status { get; set; }
        public WireStorage()
        {
            Wires = new();
        }
        public bool pushWire(Wire wire)
        {
            Wires.Add(wire);
            if (Wires is { Count: > MAX_WIRE_COUNT })
            {
                Status = WireStorageStatus.InComplete;
                return false;
            }
            Status = WireStorageStatus.Proccessing;
            return true;
        }
    }
}
