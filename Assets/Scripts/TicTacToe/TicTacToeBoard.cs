using UnityEngine;
using UnityEditor;

//A script used to record the player's game using a 2D Array.
//Extra info => indexPosition is obtained from PlayerController script upon the player pressing space. This works because UpdateTwoDBoard is only called after spacebar.

public class TicTacToeBoard : MonoBehaviour
{
    private TicTacToeBoard ticTacToeBoard;
    private GameManager_Classic gameManager;
    private char twoDToken;
    public int indexPosition;

    public char[,] twoDBoard = new char[3, 3]
    {
        { '?', '?', '?' },
        { '?', '?', '?' },
        { '?', '?', '?' }
    };


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager_Classic>();
        ticTacToeBoard = FindObjectOfType<TicTacToeBoard>();
        
    }

    //A Function that converts the indexPosition into 2D Array indexs (2ADAI)
    //Then using the 2DAI, checks if that slot is empty
    //If empty, the 2D board is updated using the 2DAI
    public int UpdateTwoDBoard(GameObject currentToken)
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
        int checkSlotResults = CheckSlot(twoDBoard[rowIndex, columnIndex]);
       
        switch (checkSlotResults)
        {
            // Place is free and players didn't reach the maximum amount of tokens
            case 0:
                twoDBoard[rowIndex, columnIndex] = twoDToken;
               // Debug.Log($"case 0: ");
               // CheckBoard();
                return 0;
            // Place is not free and players didn't reach the maximum amount of tokens
            default:
               // Debug.Log($"default: ");
               // CheckBoard();
                return 1;
            // Players have reached the maximum amount of tokens and they have chosen their own token
            case 2:
                twoDBoard[rowIndex, columnIndex] = '?';
                // Debug.Log($"case 2: ");
                // CheckBoard();
                return 2;
        }
    }


    //A function that debugs the 2Dboard
    public void CheckBoard()
    { 
        Debug.Log(twoDBoard[0, 0] + "|" + twoDBoard[0, 1] + "|" + twoDBoard[0, 2]);
        Debug.Log(twoDBoard[1, 0] + "|" + twoDBoard[1, 1] + "|" + twoDBoard[1, 2]);
        Debug.Log(twoDBoard[2, 0] + "|" + twoDBoard[2, 1] + "|" + twoDBoard[2, 2]);
        Debug.Log("------------------------");
    }

    //A function that checks if a slot is empty or not
    public int CheckSlot(char position)
    {
        if (CheckoAmountOfTokens() == true && CheckxAmountOfTokens() == true)
        {
            // Maximum amount of tokens reached and the player has chosen their own token
            if (position == twoDToken)
                return 2;
            // Maximum amount of tokens reached and the player has not chosen their own token
            else
                return 1;
        }
        // Place is free and players didn't reach the maximum amount of tokens
        else if (position == '?')
            return 0;
        // Place is not free and players didn't reach the maximum amount of tokens
        else
            return 1;
    }   

    //A function that checks if there are any empty slots.
    public bool CheckEmptySlots()
    {
        for (int rowIndex = 0; rowIndex <= 2; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex <= 2; columnIndex++)
            {
                if (twoDBoard[rowIndex, columnIndex] == '?')
                    return true;
            }
        }
        return false;
    }

    //A function that checks if player x has reached the maximum amount of tokens
    public bool CheckxAmountOfTokens()
    {
        int xCount = 0;
        int maximumTokens = 3;

        for (int rowIndex = 0; rowIndex <= 2; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex <= 2; columnIndex++)
            {
                if (twoDBoard[rowIndex, columnIndex] == 'x')
                    xCount += 1;
            }
        }
        if (xCount >= maximumTokens)
            return true;
        else
            return false;
    }

    //A function that checks if player o has reached the maximum amount of tokens
    public bool CheckoAmountOfTokens()
    {
        int oCount = 0;
        int maximumTokens = 3;

        for (int rowIndex = 0; rowIndex <= 2; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex <= 2; columnIndex++)
            {
                if (twoDBoard[rowIndex, columnIndex] == 'o')
                    oCount += 1;
            }
        }
        if (oCount >= maximumTokens)
            return true;
        else
            return false;
    }
}
