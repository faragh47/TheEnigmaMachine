using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine.Interfaces
{
    public interface IValidator
    {
        public bool CheckInstructionIsValid(string instruction);
    }
}
