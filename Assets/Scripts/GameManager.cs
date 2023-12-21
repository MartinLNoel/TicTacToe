using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    private GameObject currentToken; 

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


    }

    private void Update()
    {
        if (playerController.Controls(currentToken) == true)
        {
            currentToken = changePlayer.Switcher(currentToken, PlayerOne, PlayerTwo);
        }
    }
}
