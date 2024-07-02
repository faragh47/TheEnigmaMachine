using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine.Entities
{
    public class Punch
    {
        public char Value { get; private set; }
        public Punch(char value)
        {
            Value = value;
        }
        public Punch()
        {

        }
    }
}
