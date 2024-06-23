using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine
{
    public class StringLampboard : ILampboard<string>
    {
        public string Output { get; set; }
    }
}
