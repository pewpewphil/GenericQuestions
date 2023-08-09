using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class Anagrams : MonoBehaviour
{
    public List<string> strings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckAnagrams()
    {
        IList<IList<string>> result =GroupAnagrams(strings.ToArray());

        for (int a=0;a< result.Count; a++)
        {
            for(int b=0; b<result[a].Count; b++)
            {
                Debug.Log(result[a][b]);
            }
        }
    }

    static int HashFunction(string s)
    {
        int total = 0;
        char[] c;
        c = s.ToCharArray();

        // Summing up all the ASCII values
        // of each alphabet in the string
        for (int k = 0; k <= c.GetUpperBound(0); k++)
            total += (int)c[k];

        return total;//% array.GetUpperBound(0);
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        IList<IList<string>> returningList = new List<IList<string>>();

        // eat= ate = tea 
        // add first element 
        List<string> firstElement = new List<string>();
        firstElement.Add(strs[0]);
        returningList.Add(firstElement);

        List<int> hashedArray = new List<int>();
        hashedArray.Add(HashFunction(strs[0]));

        for (int i=1; i<strs.Length; i++)
        {
            int hashresult = HashFunction(strs[i]);
            if (hashedArray.Contains(hashresult))
            {// if we do have it we look for the element
                int index = hashedArray.FindIndex(x => x.GetHashCode() == hashresult);

                returningList[index].Add(strs[i]);
            }
            else
            {// if we don't have it we add it
                List<string> addingElement = new List<string>();
                addingElement.Add(strs[i]);
                returningList.Add(addingElement);

                hashedArray.Add(HashFunction(strs[i]));
            }
         
        }


        return returningList;
    }
}
