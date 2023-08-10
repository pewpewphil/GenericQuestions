using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSearchGrid : MonoBehaviour
{
    char[,] board = new char[,]{ { 'A', 'B', 'C', 'E' },{ 'S', 'F', 'C', 'S' },{ 'A', 'D', 'E', 'E' } };
    //char[][] board2 = new char { { 'A', 'B', 'C', 'E' }, { 'S', 'F', 'C', 'S' }, { 'A', 'D', 'E', 'E' } };
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Exist(board, "SFBA", 3, 4));
        Debug.Log(ExistNeet(board, "SFBA", 3, 4));
    }

    public struct positionStruct
    {
        public int row;
        public int col;
        public positionStruct(int _row,int _col)
        {
            row = _row;
            col = _col;
        }
    }

    /// <summary>
    /// breath first search 
    /// </summary>
    public bool SearchFunction(char[,] board,int _row, int _col, string word, int maxrow,int maxcol)
    {// mistake didn't add the max row and cols to compare . Also make sure to name the variables better 
        // queue to hold all the next elements 
        Queue<positionStruct> currentQueue = new Queue<positionStruct>();
        currentQueue.Enqueue(new positionStruct(_row, _col));
        // used elements 
        usedElements = new List<int>();
        // current counter 
        int wordIndexCounter = 1;
        // direction 
        List<positionStruct> listNavigation = new List<positionStruct>();
        listNavigation.Add(new positionStruct(0, 1));
        listNavigation.Add(new positionStruct(1, 0));
        listNavigation.Add(new positionStruct(0, -1));
        listNavigation.Add(new positionStruct(-1, 0));
        // while the que isn't empty
        while (currentQueue.Count!=0)
        {
            positionStruct currentpositionStruct = currentQueue.Dequeue();
            
            usedElements.Add(currentpositionStruct.row* maxcol + currentpositionStruct.col);// make sure we have the max col inputed 
            foreach (positionStruct dir in listNavigation)
            {
                if (currentpositionStruct.row + dir.row > -1 &&
                    currentpositionStruct.row + dir.row < maxrow &&// mistake didn't compare this 
                    currentpositionStruct.col + dir.col > -1 &&
                    currentpositionStruct.col + dir.col < maxcol &&  // the going direction isn't out of bounds 
                    !usedElements.Contains((currentpositionStruct.row + dir.row) * maxcol + (currentpositionStruct.col + dir.col)) && // if not in positionStruct queue,
                    word[wordIndexCounter] == board[currentpositionStruct.row + dir.row, currentpositionStruct.col + dir.col]) // if next element 
                {// add it 
                    wordIndexCounter++;// mistake didn't incremenet 
                    Debug.Log(board[currentpositionStruct.row, currentpositionStruct.col] + " " + (currentpositionStruct.row + dir.row) + " " + (currentpositionStruct.col + dir.col) );
                    currentQueue.Enqueue(new positionStruct(currentpositionStruct.row + dir.row, currentpositionStruct.col + dir.col));
                    if (wordIndexCounter == word.Length)// if the word is done 
                        return true;// then we return 
                }
            }
        }
        return false;
    }


    public List<int> usedElements = new List<int>();

    public bool Exist(char[,] board, string word,int rows, int cols)
    {
        if (board.Length==0)
            return false;

        for (int r=0; r< rows; r++)
        {
            for (int c=0; c< cols;c++)
            {
                if (board[r,c]== word[0])
                {
                    bool searchresult = SearchFunction(board,r, c, word, rows, cols);
                    if (searchresult)
                        return true;
                }
            }
        }
        return false; 
    }
    #region neetcode
    //T:O(N*M*4^LenOfWord), S: O(m+n+ L)
    //S: O(m+n) is for the visited array
    public bool ExistNeet(char[,] board, string word, int rows, int cols)
    {
        var visited = new bool[rows, cols];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (board[i,j] == word[0] && search(i, j, 0, word, board, visited, rows, cols))
                    return true;
            }
        }

        return false;
    }

    public bool search(int r, int c, int index, string word, char[,] board, bool[,] visited, int rows, int cols)
    {

        if (index == word.Length)
            return true;
        if (r < 0 || c < 0 || r >= rows || c >= cols || word[index] != board[r,c] || visited[r, c])
            return false;

        visited[r, c] = true;
        var result = search(r + 1, c, index + 1, word, board, visited, rows, cols) ||
          search(r - 1, c, index + 1, word, board, visited, rows, cols) ||
          search(r, c + 1, index + 1, word, board, visited, rows, cols) ||
          search(r, c - 1, index + 1, word, board, visited, rows, cols);

        visited[r, c] = false;
        return result;

    }
    #endregion 

}
