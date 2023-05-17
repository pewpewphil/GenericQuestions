using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleOverlap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Input: rec1 = [0, 0, 2, 2], rec2 = [1, 1, 3, 3]
        //Output: true

        //Example 2:
        //Input: rec1 = [0, 0, 1, 1], rec2 = [1, 0, 2, 1]
        //Output: false

        //Example 3:
        //Input: rec1 = [0, 0, 1, 1], rec2 = [2, 2, 3, 3]
        //Output: false
        int[] rec1 = new int[] { 0, 0, 1, 1};
        int[] rec2 = new int[] { 2, 2, 3, 3 };
        Debug.Log( IsRectangleOverlap(rec1, rec2));
    }

    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        // rec1 [x1,y1,x2,y2]
        bool hieghtIntersect = ((rec1[3] > rec2[1])|| (rec2[1]> rec1[3]));
        bool widthIntersect = ((rec1[2] > rec2[0])|| (rec2[0]> rec1[2]));
        //Debug.Log(hieghtIntersect + "and" + widthIntersect);
        //return hieghtIntersect && widthIntersect;
        return  (rec1[0] < rec2[2] && rec1[2] > rec2[0] && rec1[1] < rec2[3] && rec1[3] > rec2[1]);
    }
}
