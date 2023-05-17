using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ref : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int value1 = 0, value2 = 0, value3 = 0;
        increaseValue(value1);
        increaseValueStatic(value2);
        Debug.Log(value1 + "=value1 vs value 2=" + value2);

        increaseValueStaticRef(ref value2);
        Debug.Log("ref  value 2=" + value2);

        increaseValueStaticOut(value1, out value3);
        Debug.Log("out  value 3=" + value3);
    }

    void increaseValue(int value)
    {
        value++;
    }

    static void increaseValueStatic(int value)
    {
        value++;
    }

    static void increaseValueStaticRef(ref int value)
    {
        value++;
    }

    static void increaseValueStaticOut(int inputValue, out int value)
    {
        inputValue++;
        value = inputValue;
    }

    static void increaseValueStaticIn(in int inputValue, ref int value)
    {
        //inputValue++;
        value = inputValue;
        value++;
    }
}
