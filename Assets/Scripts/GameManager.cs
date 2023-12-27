using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    private GameObject currentToken;
    private TicTacToeBoard ticTacToeBoard;

    public GameObject[] Level_1_SelectedArea;
    public GameObject[] Level_2_SelectedArea;

    private PlayerController playerController;
    private ChangePlayer changePlayer;




     private void Start()
    {
        currentToken = PlayerOne;
        playerController = FindObjectOfType<PlayerController>();
        playerController.GetRequiredInformation(Level_1_SelectedArea, Level_2_SelectedArea);

        changePlayer = FindAnyObjectByType <ChangePlayer>();
        ticTacToeBoard = FindObjectOfType<TicTacToeBoard>();


    }

    //Starts by calling playerController.Controls to give a Vector3
    //Checks if the Vector3 isn't the default number (100f, 100f, 100f) 
    //If it isn't, it checks to update the 2D board
    //If it updates, it instantiates the gameobject and changes player
    private void Update()
    {
        Vector3 playerPositon = playerController.Controls();

        if (playerPositon != new Vector3(100f, 100f, 100f))
        {
            if (ticTacToeBoard.UpdateTwoDBoard(currentToken) == true)
            {
                Instantiate(currentToken, (playerPositon + new Vector3(0f, 3.12f, 0f)), Quaternion.identity);

                currentToken = changePlayer.Switcher(currentToken, PlayerOne, PlayerTwo);
            }
        }
    }
}
