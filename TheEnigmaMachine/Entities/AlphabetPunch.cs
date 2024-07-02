using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine.Entities
{
    public class AlphabetPunch
    {
        public List<Punch> Punches { get; set; }
        public AlphabetPunch()
        {
            Init();
        }
        public void Init()
        {
            Punches = new();
            for (char c = 'a'; c <= 'z'; c++)
            {
                Punches.Add(new Punch(c));
            }
        }
    }
}
