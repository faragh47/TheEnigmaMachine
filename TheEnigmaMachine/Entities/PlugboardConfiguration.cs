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
        private WireStorage _wireStorage;
        public PlugboardConfiguration(WireStorage wireStorage)
        {
            _wireStorage = wireStorage;
        }
        public PlugboardConfiguration()
        {
            _wireStorage = new();
        }
        public bool IsValidInstruction { get; set; }
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
                        _wireStorage.pushWire(new Wire(new Punch(chars[i]), null));
                        IsValidInstruction = false;
                    }
                    else
                    {
                        var result = _wireStorage.pushWire(new Wire(new Punch(chars[i]), new Punch(chars[i + 1])));
                        IsValidInstruction = IsValidInstruction & result;
                    }
                }
                if (IsValidInstruction is true)
                    _wireStorage.Status = WireStorageStatus.Complete;
            }
        }


    }
}
