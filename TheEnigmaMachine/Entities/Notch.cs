using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine.Entities
{
    public class Notch
    {
        public List<char> Values { get; private set; }
        public bool IsTouched { get; private set; }
        public Notch(List<char> values)
        {
            Values = values;
        }
        public bool CheckIsTouched(char input)
        {
            var result = (Values.Contains(input)) ;
            IsTouched = result;
            return result;
        }
    }
}
