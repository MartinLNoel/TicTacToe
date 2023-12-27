using UnityEngine;

//A script used to record the player's game using a 2D Array.
//Extra info => indexPosition is obtained from PlayerController script upon the player pressing space. This works because UpdateTwoDBoard is only called after spacebar.

public class TicTacToeBoard : MonoBehaviour
{
    private GameManager gameManager;
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
        gameManager = FindObjectOfType<GameManager>();
        
    }

    //A Function that converts the indexPosition into 2D Array indexs (2ADAI)
    //Then using the 2DAI, checks if that slot is empty
    //If empty, the 2D board is updated using the 2DAI
    public bool UpdateTwoDBoard(GameObject currentToken)
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
            CheckBoards();
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
        bool result = (position == '?') ? true: false;
        return result;
    }


}
