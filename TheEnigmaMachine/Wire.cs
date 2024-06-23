using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine
{
    public record Wire
    {
        public Wire(char key, char value)
        {
            Key = key;
            Value = value;
        }
        public char Key { get; set; }
        public char Value { get; set; }
    }
}
