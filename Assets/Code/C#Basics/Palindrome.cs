using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palindrome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
