using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DuplicateList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindDuplicate();
    }

    public void FindDuplicate()
    {
        var mylist = new List<int>() { 1, 1, 2, 2, 3, 3, 3, 4, 4 ,5 };
        var query = mylist.GroupBy(x => x)// grouping the list elements
              .Where(g => g.Count() == 1) // denote the search criteria 
              .Select(y => new { Element = y.Key, Counter = y.Count() }) // creating a new item with the element (key) and Counter (y.count)
              .ToList();

        for (int i=0;i<query.Count;i++)
        {
            Debug.Log(query[i].Element);
        }
    }

    // implement the unique names method when passed 2 arrays of names it should return an array containing the names that appear in both arrays, the arry should have no duplicate 
}
