using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeapSort : MonoBehaviour
{
    // To heapify a subtree rooted with node rootIndex which is an index in arr[]. 
    private void heapify(int[] arr, int sizeOfHeap, int rootIndex)
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
    public void heapSort(int[] arr, int arrayLength)
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
                currentArray += arr[a].ToString();
            }
            Debug.Log(currentArray);
        }
    }
}
