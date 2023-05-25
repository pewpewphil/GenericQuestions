using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeLetters : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string solution(int A, int B)
    {
        string returningString = "";
        int tempA = A, tempB = B;
        int tempACounter = 0, tempBCounter = 0;
        bool increasingA = false;

        while (tempA > 0 || tempB > 0)
        {
            // if temp A > temp B we add 
            if (tempA >= tempB)
            {
                if (!increasingA)
                {// reset if we switch
                    tempACounter = 0;
                }
                increasingA = true;
                returningString += "a";
                // counters
                tempACounter++;
                tempA--;
                if (tempACounter == 2 && tempB > 0)
                {// stop at 3 
                    returningString += "b";
                    tempACounter = 0;
                    tempB--;
                }
            }
            else if (tempB > tempA)
            {
                if (increasingA)
                {// reset if we switch
                    tempBCounter = 0;
                }
                increasingA = false;
                returningString += "b";
                // counters
                tempBCounter++;
                tempB--;
                if (tempBCounter == 2 && tempA > 0)
                {// stop at 3 
                    returningString += "a";
                    tempBCounter = 0;
                    tempA--;
                }
            }
            // if temp B > temp A we add 
            //Console.WriteLine(returningString);
        }
        return returningString;
    }
}
