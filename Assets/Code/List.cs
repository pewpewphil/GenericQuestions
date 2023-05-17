using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int> list = new List<int> { 5, 9, 7, 11 };
        Debug.Log(FindMaxSum(list));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int FindMaxSum(List<int> list)
    {

        //// first we sort the list 
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (list[j - 1] > list[j])
                {
                    int temp = list[j - 1];
                    list[j - 1] = list[j];
                    list[j] = temp;
                }
            }
        }


        // Build heap (rearrange array)
        int arrayLength = list.Count;
        int[] returnedArray =heapSort(list.ToArray(), arrayLength);
        //for (int i = arrayLength / 2 - 1; i >= 0; i--)
        //    heapify(list.ToArray(), arrayLength, i);

        //// One by one extract an element from heap
        //for (int i = arrayLength - 1; i > 0; i--)
        //{
        //    // Move current root to end
        //    int temp = list[i];
        //    list[i] = list[0];
        //    list[0] = temp;

        //    // call max heapify on the reduced heap
        //    heapify(list.ToArray(), i, 0);

        //    string currentArray = "";
        //    for (int a = 0; a < list.Count; a++)
        //    {
        //        currentArray += list[a].ToString();
        //    }
        //    Debug.Log(currentArray);
        //}
        // then we will return 2 highest
        Debug.Log(""+ returnedArray[returnedArray.Length - 1] + ""+ returnedArray[returnedArray.Length - 2]);
        return returnedArray[returnedArray.Length-1] + returnedArray[returnedArray.Length- 2];
        //throw new NotImplementedException("Waiting to be implemented.");
    }

    // To heapify a subtree rooted with node rootIndex which is an index in arr[]. 
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
    public static int[] heapSort(int[] arr, int arrayLength)
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
                currentArray += ","+arr[a].ToString();
            }
            Debug.Log(currentArray);
        }
        return arr;
    }
}
