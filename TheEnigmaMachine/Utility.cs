using System;
using System.Text.RegularExpressions;

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
                return false;
        }
        return true; // All characters are equal
    }
}
