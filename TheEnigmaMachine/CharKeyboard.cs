using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine
{
    public class CharKeyboard : IKeyboard<char>
    {
        public char Input { get; set; }
        public CharKeyboard(char input)
        {
            Input = input;
        }
    }
}
