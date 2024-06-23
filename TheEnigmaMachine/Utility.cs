using System;
using System.Text.RegularExpressions;

public static class Utility
{
    public static bool ContainsOnlyLetters(this string input)
    {
        return Regex.IsMatch(input, @"^[a-zA-Z]+$");
    }
}
