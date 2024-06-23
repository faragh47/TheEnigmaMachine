﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEnigmaMachine
{
    public class Plugboard : IPlugboard<CharKeyboard, StringLampboard>
    {
        private readonly string Wire;
        public Dictionary<char?, char?> Wires { get; set; }
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
                    Wires.Add(chars[i], chars[i]);
                }
                else
                    Wires.Add(chars[i], chars[i + 1]);
            }
        }

        public Tuple<bool, string> IsValid()
        {
            return new Tuple<bool, string>(Wire.ContainsOnlyLetters(), "Wire contain invalid charecters");
        }

        public StringLampboard Process(CharKeyboard input)
        {
            var output = new StringLampboard();
            var existInValue = Wires.FirstOrDefault(x => x.Key == input.Input).Value.ToString();
            output.Output = !string.IsNullOrEmpty(existInValue) ? existInValue : string.Empty;
            var existInKey = Wires.FirstOrDefault(x => x.Value == input.Input).Key.ToString();
            output.Output = !string.IsNullOrEmpty(existInKey) ? existInKey : output.Output;
            output.Output = string.IsNullOrEmpty(output.Output) ? input.Input.ToString() : output.Output;
            return output;
        }
    }
}