using System;
using TheEnigmaMachine.Entities;
using TheEnigmaMachine.Interfaces;

public class Rotor:IValidator
{
    private const int MAX_ALPHABET = 26;
    public string Name { get; private set; }
    private string Instruction;
    private Ring Ring;
    public Notch Notch { get; private set; }
    private readonly string Input = Alphabet.AlphabetString;
    public Rotor(string name, string instruction, string notch, char ringRotationStep, char initialStep)
    {
        Name = name;
        Instruction = instruction;
        var instructionIsOkay=CheckInstructionIsValid(instruction);

        if(instructionIsOkay is false)
            throw new ApplicationException("Invalid Instruction");

        Ring = new Ring(ringRotationStep, initialStep);
        Notch = new Notch(notch.ToCharArray().ToList());
    }

    public Tuple<char, bool> Process(char inputChar, bool forward = true)
    {
        if (!Input.Contains(inputChar))
        {
            return new Tuple<char, bool>(inputChar, false);
        }

        if (forward is true)
            Ring.rotate();

        var result=enciphering(inputChar);
       
        bool notchIsTouched = Notch.CheckIsTouched(Instruction[Input.IndexOf(result)]);

        return new Tuple<char, bool>(result, notchIsTouched);
    }

    private char enciphering(char inputChar)
    {
        int dotIndex = (Input.IndexOf(inputChar) + Input.IndexOf(Ring.InitialStep)
            - Input.IndexOf(Ring.DotPosition) + MAX_ALPHABET) % MAX_ALPHABET;
        char instructionCode = Instruction[dotIndex];
        int outputIndex = (Input.IndexOf(instructionCode) - Input.IndexOf(Ring.InitialStep)
            + Input.IndexOf(Ring.DotPosition) + MAX_ALPHABET) % MAX_ALPHABET;
        char finalOutput = Input[outputIndex];
        return finalOutput;
    }

    public bool CheckInstructionIsValid(string instruction)
    {
        var hasContainOnlyLetters = Utility.ContainsOnlyLetters(instruction);
        var isValidLenght = instruction is { Length: MAX_ALPHABET };
        return hasContainOnlyLetters & isValidLenght;
    }
}

