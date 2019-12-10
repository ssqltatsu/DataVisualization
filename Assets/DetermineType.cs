using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Determinetype
{
    public static bool TypeIsNumeric(string str)
    {
        return Regex.IsMatch(str, @"^[+-]?[0-9]+\.?[0-9]*$");
    }
}
