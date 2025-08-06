using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

//A script that is the gameflow of Tic Tac Toe
public class GameManager_Roman : MonoBehaviour
{
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    private GameObject currentToken;

    public GameObject[] Level_1_SelectedArea;
    public GameObject[] Level_2_SelectedArea;

    private PlayerController playerController;
    private TicTacToeBoard ticTacToeBoard;
    private CheckWinner checkWinner;
    private DataStorage dataStorage;
    private TokenClones tokenClones;



    [SerializeField]
    private SceneAsset sceneToLoad;

    //TO-DO
    //Last thing I was stuck with:
    //My goal was to change the title of the gameover screen to display different text depending on the result and who wins
    //I was trying to have some sort of datastorage where I would be able to save a string that contains the title
    //With that I was hoping that I could transfer the string to different scenes. Issue is that the string wouldnt save whatever I would do.



    private void Start()
    {
        currentToken = PlayerOne;
        playerController = FindObjectOfType<PlayerController>();
        playerController.GetRequiredInformation(Level_1_SelectedArea, Level_2_SelectedArea);

        ticTacToeBoard = FindObjectOfType<TicTacToeBoard>();
        checkWinner = FindObjectOfType<CheckWinner>();
        dataStorage = FindObjectOfType<DataStorage>();
        tokenClones = FindObjectOfType<TokenClones>();
    }

    // Starts by calling playerController.Controls to give a Vector3
    // Checks if the Vector3 isn't the default number (100f, 100f, 100f) 
    // If it isn't, it checks to update the 2D board
    // If it updates, it instantiates the gameobject
    // It checks if there is a winner
    // If there isn't, change the player
    private void Update()
    {
        // due to Update() this function allows for movement
        UnityEngine.Vector3 playerPositon = playerController.Controls();

        if (playerPositon != new Vector3(100f, 100f, 100f))
        {
            char twoDToken = (currentToken == PlayerOne) ? 'X' : 'O';
           
            switch (ticTacToeBoard.UpdateTwoDBoard(twoDToken))
            {
                // Place is free and players didn't reach the maximum amount of tokens
                case 0:
                    tokenClones.SpawnClone(playerPositon, currentToken);

                    if (checkWinner.CheckingWinner(twoDToken) == true)
                    {
                        DataStorage.Instance.ChangeGameOverTitle($"Winner is {twoDToken} !");

                        SceneManager.LoadScene(sceneToLoad.name);
                    }

                    currentToken = (currentToken == PlayerOne) ? PlayerTwo : PlayerOne;
                    break;
                // Place is not free and players didn't reach the maximum amount of tokens
                case 1:
                    break;
                // Players have reached the maximum amount of tokens and they have chosen their own token
                case 2:
                    tokenClones.DeleteClone(playerPositon);
                    break;
                default:
                    break;
            }
        }
    }
}
