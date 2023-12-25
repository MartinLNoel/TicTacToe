using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject[] Level_1_SelectedArea;
    GameObject[] Level_2_SelectedArea;
    private int defaultNumber = 4;
    private TicTacToeBoard ticTacToeBoard;

    private void Start()
    {
        ticTacToeBoard = FindObjectOfType<TicTacToeBoard>();
    }

    public void GetRequiredInformation (GameObject[] selectedArea1, GameObject[] selectedArea2)
    {
        Level_1_SelectedArea = selectedArea1;
        Level_2_SelectedArea = selectedArea2;
        //Token = StartToken;
    }


    public bool Controls(GameObject Token)
    {
        Level_1_SelectedArea[defaultNumber].SetActive(true);

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
            Vector3 SelectedArea_1Postion = Level_1_SelectedArea[defaultNumber].transform.position;
            Level_1_SelectedArea[defaultNumber].SetActive(false);

            if (ticTacToeBoard.UpdateTwoDBoard(Token, defaultNumber) == true)
            {
                Instantiate(Token, (SelectedArea_1Postion + new Vector3(0f, 3.12f, 0f)), Quaternion.identity);
                //ticTacToeBoard.CheckBoards();
                return true;
            }
            else
            {
                Debug.LogWarning("Error: something already there");
                return false;
            }

        }
        return false;
    }
}