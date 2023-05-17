using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaesarCipher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static string caesarCipher(string s, int k)
    {
        string output = string.Empty;

        foreach (char ch in s)
            output += cipher(ch, k);

        return output;
    }

    public static char cipher(char ch, int key)
    {
        if (!char.IsLetter(ch))
        {

            return ch;
        }

        char d = char.IsUpper(ch) ? 'A' : 'a';
        return (char)((((ch + key) - d) % 26) + d);
    }
}
