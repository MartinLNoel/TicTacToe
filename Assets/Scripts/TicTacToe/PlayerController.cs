using System.Collections.Generic;
using UnityEngine;

// A script that aims to return a new vector3 position.

// To-Do: divide visuals into another script

public class PlayerController : MonoBehaviour
{
    private TicTacToeBoard ticTacToeBoard;

    GameObject[] Level_1_SelectedArea;
    // GameObject[] Level_2_SelectedArea;
    
    private int defaultNumber = 4;

    private void Start()
    {
        ticTacToeBoard = FindObjectOfType<TicTacToeBoard>();
    }

    public void GetRequiredInformation (GameObject[] selectedArea1, GameObject[] selectedArea2)
    {
        Level_1_SelectedArea = selectedArea1;
        // Level_2_SelectedArea = selectedArea2;
    }

    // A function that records the player movement inside int defaultNumber and returns Vector3 SelectedArea_1Postion. 
    // SelectedArea_1Postion only changes when spacebar is pressed.
    public Vector3 Controls()
    {
        Level_1_SelectedArea[defaultNumber].SetActive(true);

        Vector3 SelectedArea_1Postion = new(100f, 100f, 100f);

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Level_1_SelectedArea[defaultNumber].SetActive(false);
            if (defaultNumber <= 5)
                defaultNumber += 3;

                Level_1_SelectedArea[defaultNumber].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Level_1_SelectedArea[defaultNumber].SetActive(false);
            if (defaultNumber >= 3)
               defaultNumber -= 3;

            Level_1_SelectedArea[defaultNumber].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Level_1_SelectedArea[defaultNumber].SetActive(false);
            if (defaultNumber == 3 || defaultNumber == 6)
                _ = defaultNumber;
            else if (defaultNumber  >= 1)
                defaultNumber -= 1;

            Level_1_SelectedArea[defaultNumber].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Level_1_SelectedArea[defaultNumber].SetActive(false);
            if (defaultNumber == 2 || defaultNumber == 5)
                _ = defaultNumber;
            else if (defaultNumber <= 7)
                defaultNumber += 1;

            Level_1_SelectedArea[defaultNumber].SetActive(true);
        }
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectedArea_1Postion = Level_1_SelectedArea[defaultNumber].transform.position;
            Level_1_SelectedArea[defaultNumber].SetActive(false);
            ticTacToeBoard.indexPosition = defaultNumber;
        }
        return SelectedArea_1Postion;
    }
}