using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEnigmaMachine.Enums;
using TheEnigmaMachine.Interfaces;

namespace TheEnigmaMachine.Entities
{
    public class Plugboard 
    {
        public List<Punch> Punches { get; private set; }
        public PlugboardStatus Status { get; private set; }
        public List<Wire> Wires { get; set; }
        public Plugboard(string instruction)
        {
            Wires = new();
            PlugboardConfiguration plugboardConfiguration = new PlugboardConfiguration(Wires, Status);
            plugboardConfiguration.config(instruction);
            if (plugboardConfiguration.IsValidInstruction is false)
                throw new ApplicationException("Invalid Instruction");
            Init();
        }

        private void Init()
        {
            Punches = new();
            for (char c = 'a'; c <= 'z'; c++)
            {
                Punches.Add(new Punch(c));
            }
        }

        public string Process(char punch)
        {
            var input = new Punch(punch);
            var existInOrigin = Wires
                                    .Where(x => x.Status == WireStatus.Complete).
                                     FirstOrDefault(x => x.Destination.Value == input.Value);

            var result = Convert.ToString(existInOrigin?.Origin.Value);

            if (string.IsNullOrEmpty(result))
            {
                var existInDestination = Wires
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
