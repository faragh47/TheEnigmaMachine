using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine.Interfaces
{
    public interface IWireStorage
    {
        public List<Wire> Wires { get; set; }
        bool pushWire(Wire wire);
    }
}
