using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MissingNunmberInSequence : MonoBehaviour
{
    public int[] pubArray= new int[3] { 1, 2, 4 };
    // Start is called before the first frame update
    void Start()
    {
        //List<int> listofInt = new List<int>() { 1, 2, 3, 5 };
        FindMissingException(pubArray);
    }


    #region exception function 
    public IEnumerable<int> FindMissingException(IEnumerable<int> values)
    {
        //HashSet<int> myRange = new HashSet<int>(Enumerable.Range(0, 10));
        var result = Enumerable.Range(0, 10).Except(values);
        return result;
    }


    public void  EditorRunMissionException ()
    {
        IEnumerable<int> result =FindMissingException(pubArray);
        int someInt = result.First();
        Debug.Log(someInt);
    }
    #endregion
    #region Dictonary functionaliy  
    public static List<int> DictMisginException(int[] values,int maxValue)
    {
        List<int> result = new List<int>();
        Dictionary<int, int> containDictonary = new Dictionary<int, int>();
        for (int i=0;i < values.Length; i++)
        {
            containDictonary.Add(i, values[i]);
        }

        for (int i=0; i< maxValue; i++)
        {
            if (!containDictonary.ContainsValue(i))
            {
                result.Add(i);
            }
        }

        return result;
    }
    public void EditorRunDictMissionException()
    {
        List<int> result = DictMisginException(pubArray,7);
        Debug.Log(result[0]);
    }
    #endregion

    public static int AdditionMisginException(int[] values, int maxValue)
    {
        int result = 0, addition1 = 0, addition2 = 0;
        addition2 = values.Count() * (values.Count() + 1 );//n * (n + 1) / 2

        for (int i=0;i<values.Count();i++)
        {// finding the missing number 
            addition2 -= values[i];
        }
        
        
        return addition2;
    }

    public void EditorRunAddMissionException()
    {
        //List<int> result = AdditionMisginException(pubArray, 7);
        Debug.Log(AdditionMisginException(pubArray, 7));
    }
}
