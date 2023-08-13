using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingStairs : MonoBehaviour
{
    public int stair = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckClimbStairs()
    {
        Debug.Log(ClimbStairs(stair));
    }

    public int recursiveSubtraction(int currentAmount)
    {
        Debug.Log(currentAmount);
        if (currentAmount-- <= 0|| currentAmount - 2 <= 0)
            return 1;
        else
        {
            recursiveSubtraction(currentAmount--);
            recursiveSubtraction(currentAmount - 2);
            
        }
            

        return 1;
    }

    public int ClimbStairs(int n)
    {
        //int count = 0;
        //count+=recursiveSubtraction(n);

        int variable1 = 1, variable2 = 1;
        for (int i=0;i<n-1;i++)
        {
            int oldVariable2= variable2;
            variable2 = variable2 + variable1;
            variable1 = oldVariable2;
        }
        return variable2;
    }

    
}
