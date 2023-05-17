using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class OrderingString : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string s = "SHdRVBAHskaBJSyHfD";
        string newstring = string.Concat(s.OrderBy(ch => ch));
        Debug.Log(newstring);
        s = string.Concat(s.OrderBy(ch => ch));

        Debug.Log(s);        // ABBDHHHJRSSVadfksy
    }

}
