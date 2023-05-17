using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperDigit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log( superDigit("9875", 4));
    }
    /*
     * Complete the 'superDigit' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING n
     *  2. INTEGER k
     */



    public static int superDigit(string n, int k)
    {
        //int sum = 0;

        //for (int i = 0; i < n.Length; i++)
        //{
        //    sum += n[i];
        //}
        //sum *= k;

        //Debug.Log("sum=" + sum);
        //if (sum < 10)
        //    return sum;

        //return superDigit(sum.ToString(), k-1);
        return 0;
    }

    public static int OldsuperDigit(string n, int k)
    {

        int result = 0;
        for (int i = 0; i < n.Length; i++)
        {
            result += int.Parse(n[i].ToString());
        }

        Debug.Log(result + " " + result.ToString().Length + " " + k);
        if (k == 1)
            return result;
        else
            return OldsuperDigit(result.ToString(), k - 1);
    }
}
