using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraySubset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool isArraySubset(int[] array1, int[] array2 )
    {
        bool isSubset = !array2.Except(array1).Any();

        return isSubset;
    }
}
