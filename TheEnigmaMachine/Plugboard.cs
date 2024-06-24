using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine
{
    public class Plugboard : IPlugboard<CharKeyboard, StringLampboard>
    {
        private readonly string Wire;
        public List<Wire> Wires { get; set; }
        public bool IsValidWire
        {
            get
            {
                var hasValidCharacters = !Wire.ContainsOnlyLetters();
                var hasValidSequentialCharacters = Wire.IsSequentialCharactersEqual(MAX_SEQUENTIAL_CHARACTERS);
                var hasValidWireCount = Wires is { Count: <= MAX_WIRE_COUNT };
                return hasValidCharacters & hasValidSequentialCharacters & hasValidWireCount;
            }
        }
        private const int MAX_SEQUENTIAL_CHARACTERS = 6;
        private const int MAX_WIRE_COUNT = 10;
        public Plugboard(string wire)
        {
            Wire = wire;
            translate();
        }
        private void translate()
        {
            Wires = new();
            var chars = Wire.ToCharArray();
            for (int i = 0; i < chars.Length; i += 2)
            {
                if (i + 1 > chars.Length - 1)
                {
                    Wires.Add(new Wire(chars[i], chars[i]));
                }
                else
                {
                    Wires.Add(new Wire(chars[i], chars[i + 1]));
                }
            }
        }

        public StringLampboard Process(CharKeyboard input)
        {
            if (IsValidWire is false)
                throw new ApplicationException("Invalid Wire");

            var output = new StringLampboard();
            var existInValue = Wires.FirstOrDefault(x => x.Key == input.Input);
            var value = existInValue?.Value;
            output.Output = !string.IsNullOrEmpty(value.ToString()) ? value.ToString() : string.Empty;
            var existInKey = Wires.FirstOrDefault(x => x.Value == input.Input);
            var key = existInKey?.Key;
            output.Output = !string.IsNullOrEmpty(key.ToString()) ? key.ToString() : output.Output;
            output.Output = string.IsNullOrEmpty(output.Output) ? input.Input.ToString() : output.Output;
            return output;
        }
    }
}
