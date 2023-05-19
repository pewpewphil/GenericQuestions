using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefixSums : MonoBehaviour
{
    public int[] pubArray;
    public int[] resultArray;

    public int num1 = 0, num2 = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunPrefixSums()
    {
        resultArray = new int[pubArray.Length];

        prefix_sums(pubArray, ref resultArray);

        for(int i=0;i< resultArray.Length;i++)
        {
            Debug.Log(resultArray[i]);
        }

    }

    public void prefix_sums(int[] arr, ref int[] prefixSum)
    {
        prefixSum[0] = arr[0];

        // Adding present element
        // with previous element
        for (int i = 1; i < arr.Length; ++i)
            prefixSum[i] = prefixSum[i - 1] + arr[i];
    }

    public void RunPrefixSumsWithCount()
    {
        resultArray = new int[pubArray.Length];

        prefix_sums(pubArray, ref resultArray);

        Debug.Log(countTotal(resultArray, num1, num2));
    }


    public int countTotal(int[] P, int x, int y)
    {
        return P[y+1] - P[x];
    }


}
