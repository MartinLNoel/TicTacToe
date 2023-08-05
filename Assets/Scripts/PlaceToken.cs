using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlaceToken : MonoBehaviour
{
    public GameObject Token;
    public GameObject[] SelectedArea;
    private int defaultNumber = 0;
    //get&set for pickingArea

    private void Start()
    {
        SelectedArea[defaultNumber].SetActive(true);

    }


    // Update is called once per frame
    void Update()
    {
        Controls();
    }


    public void Controls()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SelectedArea[defaultNumber].SetActive(false);
            if (defaultNumber <= 5)
                defaultNumber += 3;

                SelectedArea[defaultNumber].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SelectedArea[defaultNumber].SetActive(false);
            if (defaultNumber >= 3)
               defaultNumber -= 3;

            SelectedArea[defaultNumber].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SelectedArea[defaultNumber].SetActive(false);
            if (defaultNumber  >= 1)
                defaultNumber -= 1;

            SelectedArea[defaultNumber].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SelectedArea[defaultNumber].SetActive(false);
            if (defaultNumber <= 7 )
                defaultNumber += 1;

            SelectedArea[defaultNumber].SetActive(true);
        }
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 SelectedArea_1Postion = SelectedArea[defaultNumber].transform.position;
            SelectedArea[defaultNumber].SetActive(false);
            Instantiate(Token, (SelectedArea_1Postion + new Vector3(0f, 3.12f, 0f)), Quaternion.identity);
        }
    }
}