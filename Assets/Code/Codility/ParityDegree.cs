using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParityDegree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public int returnParityDegree(int N)
    {
        int calResult = (N & (~(N - 1)));// with ~n we take it and invert the binary option. We take the intersection of the inverted binaries this will give us the highest power of 2 
        return (int)Math.Log(calResult, 2);// we got the highest power of 2 from this, now we need to use log convert it to the highest power IE 8 = 3 , 4=2 
    }
}
