using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TheEnigmaMachine.Enums;
using TheEnigmaMachine.Interfaces;

namespace TheEnigmaMachine.Entities
{
    public class PlugboardConfiguration : IConfiguration
    {
        private const int MAX_WIRE_COUNT = 10;
        private List<Wire> Wires;
        private PlugboardStatus PlugboardStatus;
        public bool IsValidInstruction { get; set; }
        public PlugboardConfiguration(List<Wire> wires, PlugboardStatus plugboardStatus)
        {
            Wires = wires;
            PlugboardStatus = plugboardStatus;
        }
        public PlugboardConfiguration()
        {
            Wires = new();
        }
        public bool CheckInstructionIsValid(string instruction)
        {
            var hasValidCharacters = instruction.ContainsOnlyLetters();
            IsValidInstruction = hasValidCharacters;
            return hasValidCharacters;
        }
        public void config(string instruction)
        {
            if (CheckInstructionIsValid(instruction))
            {
                var chars = instruction.ToCharArray();
                for (int i = 0; i < chars.Length; i += 2)
                {
                    if (i + 1 > chars.Length - 1)
                    {
                        pushWire(new Wire(new Punch(chars[i]), null));
                        IsValidInstruction = false;
                    }
                    else
                    {
                        var result = pushWire(new Wire(new Punch(chars[i]), new Punch(chars[i + 1])));
                        IsValidInstruction = IsValidInstruction & result;
                    }
                    PlugboardStatus = PlugboardStatus.InComplete;
                }
                if (IsValidInstruction is true)
                    PlugboardStatus = PlugboardStatus.Complete;
            }
        }
        public bool pushWire(Wire wire)
        {
            Wires.Add(wire);
            if (Wires is { Count: > MAX_WIRE_COUNT })
            {
                return false;
            }
            return true;
        }


    }
}
