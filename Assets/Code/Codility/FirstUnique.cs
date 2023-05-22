using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FirstUnique : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int solution(int[] A)
    {
        var result = A.GroupBy(i => i)
        .Where(g => g.Count() == 1)
        .Select(g => g.Key);
        if (result.Count() > 0)
        {
            return result.FirstOrDefault();
        }

        return -1;
    }

}
