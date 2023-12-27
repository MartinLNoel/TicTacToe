using UnityEngine;

//A script that checks the whole board for a three-of-a-kind

//To-Do: Change so that if 2D board changes size it still works
public class CheckWinner : MonoBehaviour
{

    private TicTacToeBoard ticTacToeBoard;
    private GameManager gameManager;

    char twoDToken;

    private void Start()
    {
        ticTacToeBoard = FindObjectOfType<TicTacToeBoard>();
        gameManager = FindObjectOfType<GameManager>();
    }

    //A function that returns true if any three-of-a-kind is found on the 2D board
    public bool CheckingWinner(GameObject currentToken)
    {
        twoDToken = (currentToken == gameManager.PlayerOne) ? 'x' : 'o';

        if (CheckRows() || CheckColumn() || CheckDiagonal())
            return true;

        return false;
    }


    //A function that must check each row of the 2D board for a three-of-a-kind
    public bool CheckRows()
    {
        if (ticTacToeBoard.twoDBoard[0, 0] == twoDToken && ticTacToeBoard.twoDBoard[0, 1] == twoDToken && ticTacToeBoard.twoDBoard[0, 2] == twoDToken)
            return true;
        else if (ticTacToeBoard.twoDBoard[1, 0] == twoDToken && ticTacToeBoard.twoDBoard[1, 1] == twoDToken && ticTacToeBoard.twoDBoard[1, 2] == twoDToken)
            return true;
        else if (ticTacToeBoard.twoDBoard[2, 0] == twoDToken && ticTacToeBoard.twoDBoard[2, 1] == twoDToken && ticTacToeBoard.twoDBoard[2, 2] == twoDToken)
            return true;
        return false;
    }

    //A function that must check each column of the 2D board for a three-of-a-kind
    public bool CheckColumn()
    {
        if (ticTacToeBoard.twoDBoard[0, 0] == twoDToken && ticTacToeBoard.twoDBoard[1, 0] == twoDToken && ticTacToeBoard.twoDBoard[2, 0] == twoDToken)
            return true;
        else if (ticTacToeBoard.twoDBoard[0, 1] == twoDToken && ticTacToeBoard.twoDBoard[1, 1] == twoDToken && ticTacToeBoard.twoDBoard[2, 1] == twoDToken)
            return true;
        else if (ticTacToeBoard.twoDBoard[0, 2] == twoDToken && ticTacToeBoard.twoDBoard[2, 2] == twoDToken && ticTacToeBoard.twoDBoard[2, 2] == twoDToken)
            return true;
        return false;
    }

    //A function that must check the two diagonals of the 2D board for a three-of-a-kind
    public bool CheckDiagonal()
    {
        if (ticTacToeBoard.twoDBoard[0, 0] == twoDToken && ticTacToeBoard.twoDBoard[1, 1] == twoDToken && ticTacToeBoard.twoDBoard[2, 2] == twoDToken)
            return true;
        else if (ticTacToeBoard.twoDBoard[2, 0] == twoDToken && ticTacToeBoard.twoDBoard[1, 1] == twoDToken && ticTacToeBoard.twoDBoard[0, 2] == twoDToken)
            return true;
        return false;
    }
}
