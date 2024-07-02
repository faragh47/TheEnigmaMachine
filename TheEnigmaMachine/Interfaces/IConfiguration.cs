using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine.Interfaces
{
    public interface IConfiguration : IValidator
    {
        public void config(string instruction);
        public bool IsValidInstruction { get; set; }
    }
}
