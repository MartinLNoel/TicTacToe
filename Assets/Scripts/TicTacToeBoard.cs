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

    //Function starts with selecting which player token to use
    //Function then translates the default number into 2Darray indexs
    //Function calls CheckBoard
    //Function places token or not
    public bool UpdateTwoDBoard(GameObject currentToken, int indexPosition)
    {
        twoDToken = (currentToken == gameManager.PlayerOne) ? 'x' : 'o';
        int rowIndex;
        int columnIndex;

        switch (indexPosition)
        {
            case 0:
                rowIndex = 0;
                columnIndex = 0;
                break;
            case 1:
                rowIndex = 0;
                columnIndex = 1;
                break;
            case 2:
                rowIndex = 0;
                columnIndex = 2;
                break;
            case 3:
                rowIndex = 1;
                columnIndex = 0;
                break;
            case 4:
                rowIndex = 1;
                columnIndex = 1;
                break;
            case 5:
                rowIndex = 1;
                columnIndex = 2;
                break;
            case 6:
                rowIndex = 2;
                columnIndex = 0;
                break;
            case 7:
                rowIndex = 2;
                columnIndex = 1;
                break;
            case 8:
                rowIndex = 2;
                columnIndex = 2;
                break;
            default:
                rowIndex = 0;
                columnIndex = 0;
                Debug.LogError("Out of Range in 2D Board");
                break;
        }

        bool result = CheckSlot(twoDBoard[rowIndex, columnIndex]);

        if (result == true)
        {
            twoDBoard[rowIndex, columnIndex] = twoDToken;
            return true;
        }
        else
            return false;
    }


    //A function that debugs the 2Dboard
    public void CheckBoards()
    { 
        Debug.Log(twoDBoard[0, 0] + "|" + twoDBoard[0, 1] + "|" + twoDBoard[0, 2]);
        Debug.Log(twoDBoard[1, 0] + "|" + twoDBoard[1, 1] + "|" + twoDBoard[1, 2]);
        Debug.Log(twoDBoard[2, 0] + "|" + twoDBoard[2, 1] + "|" + twoDBoard[2, 2]);
        Debug.Log("------------------------");
    }

    //A function that checks if a slot is empty or not
    public bool CheckSlot(char position)
    {
        bool result = (position != '?') ? false : true;
        return result;
    }


}
