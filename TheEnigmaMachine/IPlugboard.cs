﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine
{
    public interface IPlugboard<Keyboard, Lampboard>: IValidator
    {
        public Lampboard Process(Keyboard input);
    }
}
