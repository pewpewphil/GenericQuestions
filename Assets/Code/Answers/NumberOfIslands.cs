using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NumberOfIslands : MonoBehaviour
{
    [SerializeField]
    public int[,] inputMap = new int[5, 5] { 
        { 1,1,1,1,0},
        { 1,1,0,1,0},
        { 1,1,1,0,0},
        { 1,1,1,0,0},
        { 1,0,0,1,1}};

    public struct rowColLoc
    {
        public int row, col;

        public rowColLoc(int inputCol,int inputRow)
        {
            row = inputRow;
            col = inputCol;
        }
    }

    public List<int> alreadyVisitedArray = new List<int>();
    // Start is called before the first frame update
    public void Start()
    {

    }

    /// <summary>
    /// This is from my thoughts 
    /// </summary>
    /// <param name="startX"></param>
    /// <param name="startY"></param>
    /// <param name="col"></param>
    /// <param name="row"></param>
    /// <returns></returns>
    private int islandTraversal(int startX, int startY, int col, int row)
    {
        Debug.Log(startX+ " "+startY);
        alreadyVisitedArray.Add((startX ) + startY * col);
        if (col != startX + 1)
        {//make sure we don't hit the max x 
            if (inputMap[startX+1, startY] == 1&& !alreadyVisitedArray.Contains((startX+1)+ startY * col))
            {
                //alreadyVisitedArray.Add((startX + 1) + startY * col);
                islandTraversal(startX + 1, startY, col, row);
            }
        }

        if (row != startY + 1)
        {//make sure we don't hit the max y
            if (inputMap[startX, startY+1] == 1 && !alreadyVisitedArray.Contains(startX + (startY + 1) * col))
            {
                //alreadyVisitedArray.Add(startX + (startY + 1) * col);
                islandTraversal(startX , startY+1, col, row);
            }
        }
        return 1;
    }

    public int IslandCounterV1(int[,] inputMap, int col, int row)
    {
        int islandCounter = 0;
        if(inputMap.Length==0)
            return 0;
        alreadyVisitedArray = new List<int>();


        // start at 0
        // go right 
        // go down 
        // pop 

        for (int r=0; r<row;r++)
        {
            for (int c=0; c<col;c++)
            {
                if (!alreadyVisitedArray.Contains(c + r  * col) && inputMap[r, c] == 1)
                {
                    Debug.Log( " new island start");
                    islandCounter += islandTraversal(c,r, col, row);
                }
                    

            }
        }

        return islandCounter;
    }

    public void CountIslandsCallV1()
    {
        Debug.Log("number of islands" + IslandCounterV1(inputMap, 5, 5));
    }


    public void CountIslandsCallV2()
    {
        Debug.Log("number of islands" + IslandCounterV2(inputMap, 5, 5));
        //Debug.Log("number of islands" + countIslands(inputMap));
    }

    public int IslandCounterV2(int[,] inputMap, int col, int row)
    {
        int islandCounter = 0;
        if (inputMap.Length == 0)
            return 0;
        alreadyVisitedArray = new List<int>();


        // start at 0
        // go right 
        // go down 
        // pop 

        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                if (!alreadyVisitedArray.Contains(c + r * col) && inputMap[r, c] == 1)
                {
                    Debug.Log(" new island startV2 "+(c + r * col));
                    BreathFirstSearch(c, r, col, row);
                    islandCounter++;
                }


            }
        }

        return islandCounter;
    }

    public void BreathFirstSearch(int startX, int startY, int col, int row)
    {
        Queue<rowColLoc> CollectionsQueue = new Queue<rowColLoc>();// create a queue
        alreadyVisitedArray.Add((startX) + startY * col);
        CollectionsQueue.Enqueue(new rowColLoc(startY, startX));

        List<rowColLoc> direction = new List<rowColLoc>();// all directions
        direction.Add(new rowColLoc(1, 0));//right
        direction.Add(new rowColLoc(0, 1));//down
        direction.Add(new rowColLoc(-1, 0));//left

        while (CollectionsQueue.Count > 0)
        {// while we have something in the queue 
            rowColLoc currentData = CollectionsQueue.Dequeue();
            Debug.Log(currentData.col + "=col||row=" + currentData.row);
            foreach (rowColLoc dir in direction)
            {
                if ((row > currentData.row + dir.row)
                    && (col > currentData.col + dir.col)// going right
                    && (0 < currentData.col + dir.col)// going left 
                    && (inputMap[currentData.col + dir.col, currentData.row + dir.row] == 1)
                    && !alreadyVisitedArray.Contains((currentData.col + dir.col) + (currentData.row + dir.row) * col))
                {
                    // if passes everything 
                    CollectionsQueue.Enqueue(new rowColLoc(currentData.col + dir.col, currentData.row + dir.row));
                    Debug.Log((currentData.col + dir.col) + "=col|ADD|row=" + (currentData.row + dir.row));
                    alreadyVisitedArray.Add((currentData.col + dir.col) + ((currentData.row + dir.row) * col));
                }

            }

        }

    }

    #region Other stuff 
    // No of rows
    // and columns
    static int ROW = 5, COL = 5;

    // A function to check if
    // a given cell (row, col)
    // can be included in DFS
    static bool isSafe(int[,] M, int row, int col,
                       bool[,] visited)
    {
        // row number is in range,
        // column number is in range
        // and value is 1 and not
        // yet visited
        return (row >= 0) && (row < ROW) && (col >= 0)
            && (col < COL)
            && (M[row, col] == 1 && !visited[row, col]);
    }

    // A utility function to do
    // DFS for a 2D boolean matrix.
    // It only considers the 8
    // neighbors as adjacent vertices
    static void DFS(int[,] M, int row, int col,
                    bool[,] visited)
    {
        // These arrays are used to
        // get row and column numbers
        // of 8 neighbors of a given cell
        int[] rowNbr
            = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] colNbr
            = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

        // Mark this cell
        // as visited
        visited[row, col] = true;

        // Recur for all
        // connected neighbours
        for (int k = 0; k < 8; ++k)
            if (isSafe(M, row + rowNbr[k], col + colNbr[k],
                       visited))
                DFS(M, row + rowNbr[k], col + colNbr[k],
                    visited);
    }

    // The main function that
    // returns count of islands
    // in a given boolean 2D matrix
    static int countIslands(int[,] M)
    {
        // Make a bool array to
        // mark visited cells.
        // Initially all cells
        // are unvisited
        bool[,] visited = new bool[ROW, COL];

        // Initialize count as 0 and
        // traverse through the all
        // cells of given matrix
        int count = 0;
        for (int i = 0; i < ROW; ++i)
            for (int j = 0; j < COL; ++j)
                if (M[i, j] == 1 && !visited[i, j])
                {
                    // If a cell with value 1 is not
                    // visited yet, then new island
                    // found, Visit all cells in this
                    // island and increment island count
                    DFS(M, i, j, visited);
                    ++count;
                }

        return count;
    }
    #endregion
}
