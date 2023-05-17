using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BookList : MonoBehaviour
{
    public int intputint;
    // Start is called before the first frame update
    void Start()
    {
        int x = NthLowestSelling(new int[] { 5, 4, 3, 2, 1, 5, 4, 3, 2, 5, 4, 3, 5, 4, 5 }, intputint);
        Debug.Log(x);
    }


    struct salesAmount 
    {// willl hold the sales amount first then sort it later and can grab for sorted list 
        public int BookListID;
        public int soldAmount;
    }

    public static int NthLowestSelling(int[] sales, int n)
    {
        //heapSort(sales, sales.Length);
        //sales=mergeSort(sales);

       // List<salesAmount> salesAmount = new List<salesAmount>();

        Dictionary<int, int> SalesValue = new Dictionary<int, int>();
        List<int> salesAmount = new List<int>();
        for (int i = 0; i < sales.Length; i++)
        { 
            if (SalesValue.ContainsKey(sales[i]))
            {// if it contains a 
                SalesValue[sales[i]]++;
                //Debug.Log(sales[i] + "=sales|| sales value=" + SalesValue[sales[i]]);
            }
            else
            {
                SalesValue.Add(sales[i], 1);
                //Debug.Log(sales[i] + "=sales added || sales value=" + SalesValue[sales[i]]);
            }
        }

        List<int>  salesKeys = SalesValue.Keys.ToList();
        for (int i = 0; i < salesKeys.Count; i++)
        {
            Debug.Log(i + "=" + salesKeys[i]);
        }

        Dictionary<int,int> sortedDict = SalesValue.OrderBy(entry => entry.Value).ToDictionary(pair => pair.Key, pair => pair.Value); ;//.take(5)
        // from entry in SalesValue orderby entry.Value ascending select entry;

        List<int>  sortedSalesKeys = sortedDict.Keys.ToList();
        for (int i = 0; i < sortedSalesKeys.Count; i++)
        {
            Debug.Log(i + "=key sortedDict value=" + sortedSalesKeys[i]);
        }

        // return sortedDict[n - 1]; // if  we want it by the value 
        return sortedDict.Keys.ToList()[n-1]; ;// if we want it by index and not by exact value
        //throw new InvalidOperationException("Waiting to be implemented.");
    }

    public static void Main(string[] args)
    {
        
    }

    public static int[] mergeSort(int[] array)
    {
        int[] left;
        int[] right;
        int[] result = new int[array.Length];
        //As this is a recursive algorithm, we need to have a base case to 
        //avoid an infinite recursion and therfore a stackoverflow
        if (array.Length <= 1)
            return array;
        // The exact midpoint of our array  
        int midPoint = array.Length / 2;
        //Will represent our 'left' array
        left = new int[midPoint];

        //if array has an even number of elements, the left and right array will have the same number of 
        //elements
        if (array.Length % 2 == 0)
            right = new int[midPoint];
        //if array has an odd number of elements, the right array will have one more element than left
        else
            right = new int[midPoint + 1];
        //populate left array
        for (int i = 0; i < midPoint; i++)
            left[i] = array[i];
        //populate right array   
        int x = 0;
        //We start our index from the midpoint, as we have already populated the left array from 0 to midpont
            for (int i = midPoint; i < array.Length; i++)
        {
            right[x] = array[i];
            x++;
        }
        //Recursively sort the left array
        left = mergeSort(left);
        //Recursively sort the right array
        right = mergeSort(right);
        //Merge our two sorted arrays
        result = merge(left, right);
        return result;
    }

    //This method will be responsible for combining our two sorted arrays into one giant array
    public static int[] merge(int[] left, int[] right)
    {
        int resultLength = right.Length + left.Length;
        int[] result = new int[resultLength];
        //
        int indexLeft = 0, indexRight = 0, indexResult = 0;
        //while either array still has an element
        while (indexLeft < left.Length || indexRight < right.Length)
        {
            //if both arrays have elements  
            if (indexLeft < left.Length && indexRight < right.Length)
            {
                //If item on left array is less than item on right array, add that item to the result array 
                if (left[indexLeft] <= right[indexRight])
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                // else the item in the right array wll be added to the results array
                else
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            //if only the left array still has elements, add all its items to the results array
            else if (indexLeft < left.Length)
            {
                result[indexResult] = left[indexLeft];
                indexLeft++;
                indexResult++;
            }
            //if only the right array still has elements, add all its items to the results array
            else if (indexRight < right.Length)
            {
                result[indexResult] = right[indexRight];
                indexRight++;
                indexResult++;
            }
        }

        //string currentArray = "";
        //for (int a = 0; a < result.Length; a++)
        //{
        //    currentArray += "," + result[a].ToString();
        //}
        //Debug.Log(currentArray);
        return result;
    }

    public static void heapify(int[] arr, int sizeOfHeap, int rootIndex)
    {
        int largest = rootIndex; // Initialize largest as root
        int left = 2 * rootIndex + 1; // left = 2*i + 1
        int right = 2 * rootIndex + 2; // right = 2*i + 2

        // If left child is larger than root
        if (left < sizeOfHeap && arr[left] > arr[largest])
            largest = left;

        // If right child is larger than largest so far
        if (right < sizeOfHeap && arr[right] > arr[largest])
            largest = right;

        // If largest is not root
        if (largest != rootIndex)
        {
            int temp = arr[rootIndex];
            arr[rootIndex] = arr[largest];
            arr[largest] = temp;
            // Recursively heapify the affected sub-tree
            heapify(arr, sizeOfHeap, largest);
        }
    }

    // main function to do heap sort
    public static void heapSort(int[] arr, int arrayLength)
    {
        // Build heap (rearrange array)
        for (int i = arrayLength / 2 - 1; i >= 0; i--)
            heapify(arr, arrayLength, i);

        // One by one extract an element from heap
        for (int i = arrayLength - 1; i > 0; i--)
        {
            // Move current root to end
            int temp = arr[i];
            arr[i] = arr[0];
            arr[0] = temp;

            // call max heapify on the reduced heap
            heapify(arr, i, 0);

            string currentArray = "";
            for (int a = 0; a < arr.Length; a++)
            {
                currentArray += "," + arr[a].ToString();
            }
            Debug.Log(currentArray);
        }
    }
}
// 1,2,2,3,3,3,4,4,4,4,5,5,5,5,5
//using System;
//using System.Collections.Generic;
//using System.Linq;

//class TwoSum
//{
//    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
//    {
//        Dictionary<int, int> map = new Dictionary<int, int>();

//        for (int i = 0; i < list.Count; i++)
//        {
//            map.Add(i, list[i]);
//        }



//        for (int i = 0; i < list.Count; i++)
//        {
//            int keyNumber = sum - list[i];
//            if (map.ContainsValue(keyNumber))
//            {
//                int returning = map[keyNumber];
//                return new Tuple<int, int>(map[keyNumber], i);
//            }
//            else
//                throw new Exception(String.Format("Key {0} was not found", keyNumber));
//        }

//        return null;
//    }

//    public static void Main(string[] args)
//    {
//        Tuple<int, int> indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
//        if (indices != null)
//        {
//            Console.WriteLine(indices.Item1 + " " + indices.Item2);
//        }
//    }
//}