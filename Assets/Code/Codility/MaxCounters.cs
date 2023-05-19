using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class MaxCounters 
{

    public int[] solution1(int N, int[] A)
    {
        int[] returnArray = new int[N];
        for (int i = 0; i < N; i++)
        {
            returnArray[i] = 0;
        }
        int currentMax = 0;

        for (int i = 0; i < A.Length; i++)
        {

            if (A[i] <= N)
            {
                //Console.WriteLine(i+" =currently1 "+A[i]);
                returnArray[A[i] - 1]++;
                if (returnArray[A[i] - 1] > currentMax)
                {
                    currentMax = returnArray[A[i] - 1];
                }
            }
            else if (A[i] - 1 == N)
            {
                //Console.WriteLine(i+" =currently2 "+A[i]);
                for (int a = 0; a < N; a++)
                {
                    //Console.WriteLine(i+" =currently3 "+A[i]);
                    returnArray[a] = currentMax;
                }
            }
        }
        return returnArray;
    }

    public int[] solution2(int N, int[] A)
    {
        int[] returnArray = new int[N];
        Array.Fill(returnArray, 0);
        int currentMax = 0;

        for (int i = 0; i < A.Length; i++)
        {

            if (A[i] <= N)
            {
                returnArray[A[i] - 1]++;
                if (returnArray[A[i] - 1] > currentMax)
                {
                    currentMax = returnArray[A[i] - 1];
                }
            }
            else if (A[i] - 1 == N)
            {
                returnArray = returnArray.Select(a => currentMax).ToArray();
            }
        }
        return returnArray;
    }
}
