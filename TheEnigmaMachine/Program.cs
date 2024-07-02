// See https://aka.ms/new-console-template for more information
using TheEnigmaMachine.Entities;

Console.WriteLine("Hello, World!");
Plugboard plugboard = new Plugboard("ABCDEFGHIJKLMNOPQRST");
Console.WriteLine(plugboard.Process('A'));
Console.WriteLine(plugboard.Process('B'));
Console.WriteLine(plugboard.Process('X'));
Console.WriteLine(plugboard.Process('.'));
