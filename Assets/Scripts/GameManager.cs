using TMPro;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

//A script that is the gameflow of Tic Tac Toe
public class GameManager : MonoBehaviour
{
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    private GameObject currentToken;

    public GameObject[] Level_1_SelectedArea;
    public GameObject[] Level_2_SelectedArea;
    public TextMeshProUGUI textMeshProUGUI;

    private PlayerController playerController;
    private ChangePlayer changePlayer;
    private TicTacToeBoard ticTacToeBoard;
    private CheckWinner checkWinner;
    private GameOverManager gameOverManager;

    [SerializeField]
    private SceneAsset sceneToLoad;




    private void Start()
    {
        currentToken = PlayerOne;
        playerController = FindObjectOfType<PlayerController>();
        playerController.GetRequiredInformation(Level_1_SelectedArea, Level_2_SelectedArea);

        changePlayer = FindAnyObjectByType <ChangePlayer>();
        ticTacToeBoard = FindObjectOfType<TicTacToeBoard>();
        checkWinner = FindObjectOfType<CheckWinner>();


    }

    //Starts by calling playerController.Controls to give a Vector3
    //Checks if the Vector3 isn't the default number (100f, 100f, 100f) 
    //If it isn't, it checks to update the 2D board
    //If it updates, it instantiates the gameobject
    //It checks if there is a winner
    //If there isn't, change the player
    private void Update()
    {
        Vector3 playerPositon = playerController.Controls();

        if (playerPositon != new Vector3(100f, 100f, 100f))
        {
            if (ticTacToeBoard.UpdateTwoDBoard(currentToken) == true)
            {
                Instantiate(currentToken, (playerPositon + new Vector3(0f, 3.12f, 0f)), Quaternion.identity);
                if (checkWinner.CheckingWinner(currentToken) == true)
                {

                    //Need coroutines to make it wait for the token to land with the winning placement;

                    Invoke(sceneToLoad.name, 5f);

                    SceneManager.LoadScene(sceneToLoad.name);

                    Debug.Log("WINNER");
                }
                else
                {
                    if (ticTacToeBoard.CheckEmptyForSlots() == false)
                    {
                        //gameOverManager.newText = "Draw";
                        gameOverManager.ChangeGameOverTitle("DRAW");

                        Invoke(sceneToLoad.name, 5f);

                        SceneManager.LoadScene(sceneToLoad.name);

                        Debug.Log("DRAW");
                    }
                }       
                currentToken = changePlayer.Switcher(currentToken, PlayerOne, PlayerTwo);
            }
        }
    }
}
