using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palindrome 
{

    public bool isPalindrome(string input)
    {
        for (int a = 0; a < input.Length / 2; a++)
        {
            if (input[a] != input[input.Length - a])
            {
                return false;
            }
        }

        return true;
    }
}
