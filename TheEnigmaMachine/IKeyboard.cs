    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine
{
    public interface IKeyboard<T>
    {
        public T Input { get; set; }
    }
}
