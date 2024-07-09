using System;
using System.Text.RegularExpressions;
using TheEnigmaMachine.Entities;

public static class Utility
{
    public static bool ContainsOnlyLetters(this string input)
    {
        return Regex.IsMatch(input, @"^[a-zA-Z]+$");
    }

    public static bool IsSequentialCharactersEqual(this string input, int length)
    {

        char firstChar = input[0];
        int counter = 0;
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == firstChar)
            {
                counter++;
            }
            else
            {
                firstChar = input[i];
                counter = 0;
            }
            if (counter == length)
                return false;// All characters are equal
        }
        return true; 
    }
    public static char ShiftChar(char c)
    {
        string alphabet =Alphabet.AlphabetString;
        if (alphabet.Contains(c))
        {
            int newIndex = (alphabet.IndexOf(c) + 1) % 26;
            c = alphabet[newIndex];
        }
        return (char)c;
    }

    public static string ShiftString(string input, bool isRight)
    {
        string alphabet = Alphabet.AlphabetString;
        string shiftedString = "";
        int counter = isRight ? -1 : 1;
        foreach (char c in input)
        {
            if (alphabet.Contains(c))
            {
                if (alphabet.IndexOf(c) == 0 && isRight is true)
                {
                    shiftedString += alphabet[25];
                }
                else
                {
                    int newIndex = (alphabet.IndexOf(c) + counter) % 26;
                    shiftedString += alphabet[newIndex];
                }
            }
        }
        return shiftedString;
    }
}
