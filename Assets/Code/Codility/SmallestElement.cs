using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SmallestElement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int solutionOne(int[] A)
    {
        Dictionary<int, int> items = new Dictionary<int, int>();
        for (int i = 0; i < A.Length; i++)
        {
            items.Add(i, A[i]);
        }
        for (int i = 1; i < 100; i++)
        {
            if (!items.ContainsValue(i))
            {
                return i;
            }

        }

        return 0;
    }

    public int solutionTwo(int[] A)
    {
        if (A.Length==0 || !A.Any(x => x == 1)) { return 1; }// 1) empty array 2) A does not contain 1, Then We will return 1 
        // check positives 
        var positiveList = A.Where(n => n > 0);// getting only the positives into a list  
        int resultAmount = positiveList.Count(); // the positive count 
        var positiveCount = Enumerable.Range(1, resultAmount);// creating a temp list of all the positive numbers 
        var failNumber = positiveCount.Except(positiveList);// fail numbers are numbers we do not have 
        // return results 
        if (!failNumber.Any()) { return A.Max() + 1; }// if we don't have anything in the fail number meaning it didn't match 
        return failNumber.FirstOrDefault();// finding the smallest 
    }

    public int solutionTwoNoComments(int[] A)
    {
        if (A.Length == 0 || !A.Any(x => x == 1)) { return 1; }

        var positiveList = A.Where(n => n > 0);
        int resultAmount = positiveList.Count();
        var positiveCount = Enumerable.Range(1, resultAmount);
        var failNumber = positiveCount.Except(positiveList);

        if (!failNumber.Any()) { return A.Max() + 1; }
        return failNumber.FirstOrDefault();
    }
}
