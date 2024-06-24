// See https://aka.ms/new-console-template for more information
using TheEnigmaMachine;

Console.WriteLine("Hello, World!");
Plugboard plugboard = new Plugboard("ABCDEFGHIJKLMNOPQRST");
var keyboad = new CharKeyboard('A');
Console.WriteLine(plugboard.Process(keyboad).Output);
keyboad = new CharKeyboard('B');
Console.WriteLine(plugboard.Process(keyboad).Output);
keyboad = new CharKeyboard('X');
Console.WriteLine(plugboard.Process(keyboad).Output);
keyboad = new CharKeyboard('.');
Console.WriteLine(plugboard.Process(keyboad).Output);
