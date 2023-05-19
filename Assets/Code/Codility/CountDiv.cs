using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDiv : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("solution1 " + SolutionEnhanced(11, 345, 17));
        Debug.Log("solution2 " + SolutionEnhanced(10, 10, 20));
    }
    int SolutionSimple(int A, int B, int K)
    {
        int count = 0;
        for (int i = A; i < B; i++)
        {
            if (i % K == 0)
            {
                count++;
            }
        }
        return count;
    }
    //cases 
    //A = 11, B = 345, K = 17
    //A = B in {0,1}, K = 11
    //A = 10, B = 10, K in {5,7,20}

    int SolutionEnhanced(int A, int B, int K)
    {
        //int returningNumber = 0;
        //if (A % K == 0)
        //{
        //    returningNumber++;
        //}

        //int resultNumber = B - A;
        int inclusive = (A % K == 0 ? 1 : 0);


        return B / K - A / K + inclusive;
    }
}
