using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberSimple : MonoBehaviour
{
    public int[] robbingValues = new int[] { 1, 2, 3, 1, 7 };
    // Start is called before the first frame update

    public void Start()
    {
        RobSimple();
    }
    public void RobSimple()
    {
        Debug.Log(Rob(robbingValues));
    }

    public int Rob(int[] nums)
    {
        int rob1 = 0, rob2 = 0;

        foreach (int num in nums)
        {
           
            int temp = Mathf.Max(num + rob1, rob2);
            rob1 = rob2;
            rob2 = temp;
            Debug.Log(rob2 + "vs" + rob1);
        }

        return rob2;
    }
}
