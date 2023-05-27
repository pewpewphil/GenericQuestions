using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class LongestPassword 
{
    public int solution1(string S)
    {
        int maxCount = -1;// -1 is defualt for none
        string[] substrings = S.Split(' ');

        for (int i = 0; i < substrings.Length; i++)
        {

            if (substrings[i].Count(char.IsLetter) % 2 == 0 && substrings[i].Count(char.IsDigit) % 2 == 1 && substrings[i].All(char.IsLetterOrDigit))
            {// Long check for the letters 
                maxCount = Math.Max(maxCount,substrings[i].Length);// make sure 
            }
        }
        return maxCount;
    }
}
