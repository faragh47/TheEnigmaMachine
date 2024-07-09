using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine.Entities
{
    public class Ring
    {
        public char DotPosition { get; private set; }
        public char InitialStep { get; private set; }
        public Ring(char dotPosition, char initialStep)
        {
            DotPosition = dotPosition;
            InitialStep = initialStep;
        }
        public void rotate()
        {
            InitialStep=Utility.ShiftChar(InitialStep);
        }
    }
}
