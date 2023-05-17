using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Answers : MonoBehaviour
{
    public int target = 9;
    public int[] inputArray1;
    public int[] inputArray2;
    public string inputString;
    
    // Start is called before the first frame update
    void Start()
    {
        bool isBlue = false;
        int BlueColor = isBlue ? 0 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    #region twoSum 
    //Input: nums = [3,3], target = 6
    //Output: [0,1]
    public void AnswerTwoSum()
    {
        int[] nums = new int[6] { 1, 3, 5, 7, 5, 9 };
        int[] returning = new int[2] { 0, 1 };
        returning = TwoSumUnique(nums, target);
        Debug.Log(string.Format(" 1={0} 2={1}",returning[0],returning[1]));

        foreach(int numm in nums)
            {

        }
    }

    public int[] TwoSum(int[] nums, int target)
    {
        Debug.Log("target=" + target);
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            map.Add(nums[i], i);
            Debug.Log(map[nums[i]]);
        }

        

        int[] returningArray = new int[2] { 0,0};
        for (int i=0; i< nums.Length;i++)
        {
            int keyNumber = target - nums[i];
            if (map.ContainsKey(keyNumber))
            {
                //int outValue = 0;
                //map.TryGetValue(keyNumber, out outValue);
                Debug.Log(keyNumber + " and " + map[keyNumber]);
                int returning= map[keyNumber];
                return new int[2] { map[keyNumber], i };
            }
        }
        return returningArray;
    }

    public int[] TwoSumUnique(int[] nums, int target)
    {
        //Debug.Log("target=" + target);
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            map.Add(i, nums[i]);
            //Debug.Log(map[i]);
        }


        int[] returningArray = new int[2] { 0, 0 };
        for (int i = 0; i < nums.Length; i++)
        {// going through all the numbers 
            int keyNumber = target - nums[i];// finding the key number since it should be only 1
            map.TryGetValue(keyNumber, out var result);
            
            int myKey = map.FirstOrDefault(x => x.Value == keyNumber).Key;// find it by the key value 
            if (map.ContainsValue(keyNumber)&& result != i)// was mykey 
            {// found key and the current key value 
                //Debug.Log(keyNumber);
                int returning = myKey;
                return new int[2] { returning, i };
            }
        }
        return returningArray;
    }
    #endregion

    #region Add two numbers 

    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
      }
    //Input: l1 = [2,4,3], l2 = [5,6,4]
    //Output: [7,0,8]
    //Explanation: 342 + 465 = 807.
    public void AnswerTwoNumbers()
    {
        int[] l1 = new int[3] { 2,4,3};
        int[] l2= new int[3] { 5,6,4 };
        LinkedList<int> linkedList1= new LinkedList<int>(inputArray1);
        LinkedList<int> linkedList2 = new LinkedList<int>(inputArray2);// new LinkedListNode<int>();
        //Debug.Log(string.Format("{0}=first {1}=last",linkedList1.First.Value, linkedList1.Last.Value));
        LinkedList<int> returnLinkedList= AnswerTwoNumbers(linkedList1, linkedList2);
        LinkedListNode<int> node= returnLinkedList.First;
        string displayString = "";
        while (node != null)
        {
            displayString += node.Value;
            if (node != null)
                node = node.Next;
        }
        Debug.Log(string.Format("result={0}", displayString));
    }

    public LinkedList<int> AnswerTwoNumbers(LinkedList<int> linkedList1 , LinkedList<int> linkedList2)
    {
        LinkedList<int> returningList = new LinkedList<int>();

        LinkedListNode<int> nodeL = linkedList1.Last;
        LinkedListNode<int> nodeS = linkedList2.Last;
        int carryover= 0;

        while (nodeL != null||nodeS != null)
        {
            //Debug.Log(nodeP.Value);
            //nodeP = nodeP.Previous;

            int SVal=0, LValue=0, resultInt = 0;
            if (nodeS != null)
            {
                SVal = nodeS.Value;
                nodeS = nodeS.Previous;
                
            }
            if (nodeL != null)
            {
                LValue = nodeL.Value;
                nodeL = nodeL.Previous;
               
            }
            resultInt = SVal + LValue + carryover;
            carryover = resultInt / 10;
            resultInt = resultInt % 10;
            Debug.Log(string.Format("result Int={0} carryover={1}", resultInt, carryover));

            returningList.AddFirst(new LinkedListNode<int>(resultInt));
        }

        if (carryover>0)
        {// there is a carry over 
            returningList.AddFirst(new LinkedListNode<int>(carryover));
        }
        return returningList;
    }

    #endregion

    #region substring
    //Given a string s, find the length of the longest substring without repeating characters.

    //Example 1:
    //Input: s = "abcabcbb"
    //Output: 3
    //Explanation: The answer is "abc", with the length of 3.
    public void AnswerSubString()
    {
        Debug.Log(lengthOfLongest(inputString));
    }
    // mistake: didn't do full reset 
    public int lengthOfLongest (string s)
    {
        char lastChar= s[0];
        int returningNumber = 1, largest =0;
        Dictionary<char, int> charMap = new Dictionary<char, int>();
        charMap.Add(s[0], 0);// adding first 
        for (int i=1; i<s.Length;i++)
        {// start at 1 because we cannot compare 1 against nothing
           
            if (!charMap.ContainsKey(s[i]))
            {//  not found and keep going  
                charMap.Add(s[i], i);
                returningNumber ++;
            }
            else
            {// found and reset 
                if (largest < returningNumber)
                    largest = returningNumber;

                charMap = new Dictionary<char, int>();
                charMap.Add(s[i], i);
                returningNumber = 1;
            }
            Debug.Log(string.Format(" 0={0} 1={1}", returningNumber, s[i]));
            lastChar = s[i];
        }

        return largest;
    }

    #endregion

    #region median of two sorted arrays 
    //Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

    //The overall run time complexity should be O(log (m+n)).
    //1) grab 1 of each then put it into the array 
    //2) insert both then sort (insertion sort)


    //1)Find the length of the smaller arrays of the two.We will perform binary search on the smaller array.
    //2) For binary search, we will have two pointers - start = 0 and end = m(assuming m is the smaller length).
    //3)Loop until start meets end i.e., while (start <= end) { ... }.
    //4)Calculate the partition index(partitionA) for a which is the mid-point of start and end i.e., (start + end) / 2.
    //5)Calculate the partition index(partitionB) for b which is (m + n + 1) / 2 - partitionA.
    //6)Find the maximum element in the left of a and b and minimum element in the right of a and b.
    //7)Now, we can have three cases -
    //(a) If (maxLeftA <= minRightB && maxLeftB <= minRightA), then we have hit the jackpot . Now, we can return the median based on(m + n) is even or odd.

    //(b) Else If(maxLeftA > minRightB), it means, we are too far on the right and we need to go on the left, so, set end = partitionA - 1.

    //(c) Else, we are too far on the left and we need to go to the right, so, set start = partitionA + 1.
    static int BinarySearch(int[] elements, int searchingElement)
    {
        int left = 0;
        int right = elements.Length - 1;
        int middle = (int)((left + right) / 2);
        while (elements[middle]!=searchingElement && left< right)
        {
            if (left <elements[middle])
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
            middle = (int)((left + right) / 2);
        }

        return (elements[middle] != searchingElement) ? -1 : middle;
    }

    public void heapSortAnswer()
    {
        int[] arrayToSort = new int[8] { 1, 4, 6, 2, 3, 5, 8,7 };
        heapSort(arrayToSort, arrayToSort.Length);
        for(int i = 0; i < arrayToSort.Length; i++)
        {
            Debug.Log(arrayToSort[i]);
        }
       
    }

    // To heapify a subtree rooted with node rootIndex which is an index in arr[]. 
    public void heapify(int[] arr, int sizeOfHeap, int rootIndex)
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
    #endregion
}
