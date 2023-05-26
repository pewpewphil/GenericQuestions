using System.Collections;
using System.Collections.Generic;

public class MinTwoSlice 
{


    public int SliceTwo(int[] v)
    {// FROM https://molchevskyi.medium.com/best-solutions-for-codility-lessons-lesson-5-prefix-sums-68b716f9d825
        int v_size = v.Length;
        // The minimal average of the first slice
        double min_avg_value = (v[0] + v[1]) / 2.0;
        // The start position of the first
        // slice with minimal average    
        int min_avg_pos = 0;
        for (int i = 0; i < v_size - 2; ++i)
        {
            // Try the next 2-element slice
            double min_avg_slice_2 = (v[i] + v[i + 1]) / 2.0;
            if (min_avg_value > min_avg_slice_2)
            {
                min_avg_value = min_avg_slice_2;
                min_avg_pos = i;
            }
            // Try the next 3-element slice
            double min_avg_slice_3 = (v[i] + v[i + 1] + v[i + 2]) / 3.0;
            if (min_avg_value > min_avg_slice_3)
            {
                min_avg_value = min_avg_slice_3;
                min_avg_pos = i;
            }
        }
        // Try the last 2-element slice
        double min_avg_last_slice = (v[v_size - 2] + v[v_size - 1]) / 2.0;
        if (min_avg_value > min_avg_last_slice)
        {
            min_avg_pos = v_size - 2;
        }
        return min_avg_pos;
    }
}
