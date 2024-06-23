using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine
{
    public interface ILampboard<T>
    {
        public T Output { get; set; }
    }
}
