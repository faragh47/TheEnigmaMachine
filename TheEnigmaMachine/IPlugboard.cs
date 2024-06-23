using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine
{
    public interface IPlugboard<Keyboard, Lampboard>
    {
        public Lampboard Process(Keyboard input);
        public Tuple<bool, string> IsValid();
    }
}
