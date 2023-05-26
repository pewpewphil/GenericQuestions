using System.Collections;
using System.Collections.Generic;
using System;

public class FloodDepth 
{

    public int solution1(int[] A)
    {
        int curretTallest = 0;
        int BiggestDepth = 0;
        int tempDepth = 0;
        // find tallest1, find next tallest 
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] >= curretTallest)
            {
                curretTallest = A[i];
                if (tempDepth > BiggestDepth)
                {
                    BiggestDepth = tempDepth;
                }
                continue;
            }
            if (curretTallest - A[i] > tempDepth)
            {
                tempDepth = curretTallest - A[i];
            }
        }

        return BiggestDepth;
    }

    public int solution2(int[] A)
    {
        int highestIdx = 0;
        int lowestIdx = 0;
        int max = 0;

        for (int i = 1; i < A.Length; i++)
        {
            int current = A[i];
            int highest = A[highestIdx];
            int lowest = A[lowestIdx];
            if (current > highest)
            {// new high reset everything
                max = Math.Max(highest - lowest, max);
                highestIdx = i;
                lowestIdx = highestIdx;
            }
            else if (current > lowest)
            {// new temp high get the current max 
                max = Math.Max(current - lowest, max);
            }
            else if (current < lowest)
            {// new low set temp low 
                lowestIdx = i;
            }
        }
        return max;

    }
}
