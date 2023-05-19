using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class TimeComplexCodility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// A small frog wants to get to the other side of the road. The frog is currently located at position X and wants to get to a position greater than or equal to Y. The small frog always jumps a fixed distance, D.
    /// Count the minimal number of jumps that the small frog must perform to reach its target.
    /// Write a function:

//class Solution { public int solution(int X, int Y, int D); }
//    that, given three integers X, Y and D, returns the minimal number of jumps from position X to a position equal to or greater than Y.
//    For example, given:

//  X = 10
//  Y = 85
//  D = 30
//the function should return 3, because the frog will be positioned as follows:

//after the first jump, at position 10 + 30 = 40
//after the second jump, at position 10 + 30 + 30 = 70
//after the third jump, at position 10 + 30 + 30 + 30 = 100
//Write an efficient algorithm for the following assumptions:

    ///X, Y and D are integers within the range[1..1, 000, 000, 000];
    /// X ≤ Y.
    /// </summary>
    public int FrogJump(int X, int Y, int D)
    {
        return ((Y - X) % D == 0) ? (Y - X) / D : (Y - X) / D + 1;
    }


//    An array A consisting of N different integers is given.The array contains integers in the range[1..(N + 1)], which means that exactly one element is missing.

//Your goal is to find that missing element.

//Write a function:

//class Solution { public int solution(int[] A); }

//that, given an array A, returns the value of the missing element.
    public int MissingNumber(int[] A)
    {
        //solution 1 
        //if (A.Length == 0)
        //    return 1;
        //else if (A.Length == 1)
        //    return 2;

        //int returningNumber = 0;

        //int something= A.Sum();
        //Array.Sort(A);
        //for (int i = 0; i < A.Length; i++)
        //{
        //    if (A[i] != i + 1)
        //    {
        //        return i + 1;
        //    }
        //    returningNumber=i;
        //}
        //return returningNumber;

        //solution 2 
        if (!A.Any() || !A.Any(x => x == 1)) { return 1; }// Case 1 A is empty, Case 2 a Doesn't contain : so we will return 1  
        int size = A.Length;
        var numberTwoList = Enumerable.Range(1, size);// quick creation of a list from A to the length 
        var failNumber = numberTwoList.Except(A);// find which numbers do not exsist in A and the other list 
        if (!failNumber.Any()) { return A.Max() + 1; }// if we cannot find any numbers then we will take the next larget number 
        return failNumber.FirstOrDefault();// else (normally) we will return the first or default 

        //except exploration 
        //List<int> someList1 = new List<int>() { 1, 2, 3, 4 };
        //List<int> someList2 = new List<int>() { 1, 2, 3 ,5};
        //var result = someList1.Except(someList2);
    }

}
