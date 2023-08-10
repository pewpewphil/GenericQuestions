using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermutationInString : MonoBehaviour
{
    //Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
    //In other words, return true if one of s1's permutations is the substring of s2.
    public string string1 = "pop";
    public string string2 = "opposition";
    // Start is called before the first frame update
    void Start()
    {
        CallFunction();
    }

    public void CallFunction()
    {
        Debug.Log(CheckInclusion(string1, string2));
    }

    static int HashFunction(string s)
    {
        int total = 0;
        char[] c;
        c = s.ToCharArray();

        // Summing up all the ASCII values
        // of each alphabet in the string
        for (int k = 0; k <= c.GetUpperBound(0); k++)
            total += (int)c[k];

        return total;
    }

    public bool CheckInclusion(string s1,string s2)
    {
        if (s2.Length< s1.Length)
            return false;
        int hashOfS1 = HashFunction(s1);
        int hashOfS2;
        string currentString = s2.Substring(0, s1.Length);
        for (int i= 0; i< s2.Length;i++ )
        {
            
            currentString = s2.Substring(i, s1.Length);
            Debug.Log(currentString);
            hashOfS2 = HashFunction(currentString);
            if (hashOfS2== hashOfS1)
            {
                return true;
            }
        }

        return false; 
    }
}
