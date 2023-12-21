using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TicTacToeBoard : MonoBehaviour
{
    private GameManager gameManager;
    private char twoDToken;

    private char[,] twoDBoard = new char[3, 3]
    {
        { '?', '?', '?' },
        { '?', '?', '?' },
        { '?', '?', '?' }


      /*
        { (0,0), (0,1), (0,2) },
        { (1,0), (1,1), (1,2) },
        { (2,0), (2,1), (2,2) } 
      
        Left     = (0,-1)
        Right    = (0,+1)
        Up       = (-1,0)
        Down     = (+1,0)

        private bool IsCoordinateValid(int x, int y, char[,] twoDArray)
        {
            int rows = twoDArray.GetLength(0);
            int cols = twoDArray.GetLength(1);

            return (x >= 0 && x < rows) && (y >= 0 && y < cols);
        }

        { 0, 1, 2 },
        { 3, 4, 5 },
        { 6, 7, 8 } 

        Left     = -1
        Right    = +1
        Up       = -3
        Down     = +3

        0 = 1,2,4,8,3,6
        1 = 0,2,4,7
        2 = 0,1,4,6,5,8
        3 = 0,6,4,5
        4 = 0,1,2,3,5,6,7,8
        5 = 2,8,3,4
        6 = 0,3,2,4,7,8
        7 = 6,8,1,4
        8 = 0,4,2,5,6,7
       
      */
    };

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    public void UpdateTwoDBoard(GameObject currentToken, int index)
    {
        twoDToken = (currentToken == gameManager.PlayerOne) ? 'x' : 'o';

        switch (index)
        {
            case 0:
                twoDBoard[0, 0] = twoDToken;
                break;
            case 1:
                twoDBoard[0, 1] = twoDToken;
                break;
            case 2:
                twoDBoard[0, 2] = twoDToken;
                break;
            case 3:
                twoDBoard[1, 0] = twoDToken;
                break;
            case 4:
                twoDBoard[1, 1] = twoDToken;
                break;
            case 5:
                twoDBoard[1, 2] = twoDToken;
                break;
            case 6:
                twoDBoard[2, 0] = twoDToken;
                break;
            case 7:
                twoDBoard[2, 1] = twoDToken;
                break;
            case 8:
                twoDBoard[2, 2] = twoDToken;
                break;
        }
        //CheckBoards();
    }


    public void CheckBoards()
    { //GameObject[] threeDBoard,
        /*
        int rows = twoDBoard.GetLength(0);
        int cols = twoDBoard.GetLength(1);

        // Iterate through the elements of the 2D array
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Debug.Log(twoDBoard[i, j] + "");
            }
            Debug.Log("\n");
        }*/
        Debug.Log("0: " + twoDBoard[0, 0]);
        Debug.Log("1: " + twoDBoard[0, 1]);
        Debug.Log("2: " + twoDBoard[0, 2]);
        Debug.Log("3: " + twoDBoard[1, 0]);
        Debug.Log("4: " + twoDBoard[1, 1]);
        Debug.Log("5: " + twoDBoard[1, 2]);
        Debug.Log("6: " + twoDBoard[2, 0]);
        Debug.Log("7: " + twoDBoard[2, 1]);
        Debug.Log("8: " + twoDBoard[2, 2]);
    }


}
