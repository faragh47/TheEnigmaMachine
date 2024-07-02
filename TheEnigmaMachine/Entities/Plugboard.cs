using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEnigmaMachine.Enums;
using TheEnigmaMachine.Interfaces;

namespace TheEnigmaMachine.Entities
{
    public class Plugboard : IPlugboardOperation
    {
        public AlphabetPunch AlphabetPunch { get; set; }
        public WireStorage WireStorage { get; set; }
        private PlugboardConfiguration PlugboardConfiguration { get; set; }
        public Plugboard(string instruction)
        {
            WireStorage = new();
            PlugboardConfiguration = new PlugboardConfiguration(WireStorage);
            PlugboardConfiguration.config(instruction);
        }

        public string Process(char punch)
        {
            if (PlugboardConfiguration.IsValidInstruction is false)
                throw new ApplicationException("Invalid Instruction");
            var input = new Punch(punch);
            var existInOrigin = WireStorage.Wires
                                    .Where(x => x.Status == WireStatus.Complete).
                                     FirstOrDefault(x => x.Destination.Value == input.Value);

            var result = Convert.ToString(existInOrigin?.Origin.Value);

            if (string.IsNullOrEmpty(result))
            {
                var existInDestination = WireStorage.Wires
                                     .Where(x => x.Status == WireStatus.Complete).
                                      FirstOrDefault(x => x.Origin.Value == input.Value);

                result = Convert.ToString(existInDestination?.Destination.Value);
            }
            if (string.IsNullOrEmpty(result))
            {
                result = input.Value.ToString();
            }
            return result;
        }
    }
}
