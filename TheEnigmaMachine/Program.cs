using System;
using System.Collections.Generic;


// Usage Example
public class Program
{
    public static void Main()
    {
        Rotor rotorI = new Rotor("I", "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "Q", 'Z', 'O');
        Console.WriteLine(rotorI.Process('A', true)); // ('H', True)
        Console.WriteLine(rotorI.Process('B', true)); // ('B', False)
        Console.WriteLine(rotorI.Process('C', true)); // ('I', False)
        Console.WriteLine(rotorI.Process('.', true)); // ('.', False)
        Console.WriteLine(rotorI.Process('D', true)); // ('I', False)
        Console.WriteLine(rotorI.Process('E', true)); // ('I', False)
        Console.WriteLine(rotorI.Process('F', true)); // ('J', False)
    }
}
