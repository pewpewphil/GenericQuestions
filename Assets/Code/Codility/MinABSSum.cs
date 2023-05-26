using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class MinABSSum 
{
    public int solution(int[] A)
    {
        int result = 0;
        if (A.Length == 0)
        {
            return result;
        }

        Array.Sort(A);

        var negArray = A.Where(i => i < 0);
        //int maxNeg=negArray.Max();
        int arraySize = negArray.ToArray().Length;
        int extrasize = (A.Length - arraySize < 5 ? A.Length - arraySize : 5);
        result = 100;

        for (int i = arraySize - 1; i < arraySize + extrasize; i++)
        {
            for (int j = arraySize; j < arraySize + extrasize; j++)
            {
                if (A[i] + A[j] >= 0)
                {
                    result = Math.Min(result, A[i] + A[j]);
                }
            }
        }
        return result;
    }

    public int solutionB(int[] A)
    {
        if (A.Length == 0) return 0;
        if (A.Length == 1) return A[0];

        int sum = 0;
        int max = A[0];

        for (int i = 0; i < A.Length; i++)
        {
            A[i] = Math.Abs(A[i]);
            sum += A[i];
            max = Math.Max(A[i], max);
        }

        int[] count = new int[max + 1];
        for (int num = 0; num < A.Length; num++)
        {
            count[num]++;
        }

        int[] dp = new int[sum + 1];
        Array.Fill(dp, -1);

        dp[0] = 0;

        for (int i = 0; i <= max; i++)
        {
            if (count[i] > 0)
            {
                for (int val = 0; val <= sum; val++)
                {
                    if (dp[val] >= 0) dp[val] = count[i];
                    else if (val >= i && dp[val - i] > 0)
                    {
                        dp[val] = dp[val - i] - 1;
                    }
                }
            }
        }

        int result = sum;
        for (int i = 0; i <= sum / 2; i++)
        {
            if (dp[i] >= 0) result = Math.Min(result, sum - (2 * i));
        }
        return result;
    }
}
