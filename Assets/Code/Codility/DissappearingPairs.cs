using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissappearingPairs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string Solution(string S)
    {//O(2 * *N)
        // Implement your solution here
        String returningString = S;
        bool goneThrough = false;
        while (!goneThrough && returningString.Length > 1)
        {
            for (int i = 0; i < returningString.Length - 1; i++)
            {
                //Console.WriteLine(i+"vs "+(returningString.Length-1));
                if (returningString[i] == returningString[i + 1])
                {
                    returningString = returningString.Remove(i, 2);
                    goneThrough = false;
                    //Console.WriteLine("mod"+returningString);
                    break;
                }
                // if we find pair, we remove the element 
                // else we keep on going through 
                else if (i == returningString.Length - 2)
                { // -2 beccause we are checking for the other 2 
                    //Console.WriteLine("goneThrough");
                    goneThrough = true;
                    break;
                }

            }
            //Console.WriteLine("|"+returningString+"|=returningString"+returningString.Length);
        }

        return returningString;
    }

    public string Solution2(string S)
    {//
        string returningString = "";
        foreach (char ch in S)
        {
            int size = returningString.Length;
            if (size > 0 && returningString[size - 1] == ch)
            {
                returningString.Remove(size - 1);
            }
            else
                returningString += (ch);
        }

        return returningString;
    }
}
