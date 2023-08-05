using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceToken : MonoBehaviour
{
    public GameObject Token;
    public GameObject DefaultArea;
    public GameObject[] SelectedArea;
    //get&set for pickingArea

    private void Start()
    {
        DefaultArea.SetActive(true);

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
            DefaultArea.SetActive(false);
            DefaultArea = SelectedArea[3];
            DefaultArea.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            DefaultArea.SetActive(false);
            DefaultArea = SelectedArea[0];
            DefaultArea.SetActive(true);
        }

        Vector3 SelectedArea_1Postion = DefaultArea.transform.position;
        //Debug.Log(SelectedArea_1Postion);
        //To-DO: Make it so that when you press a button it counts up words. So that you can change where you want to place it with pressing one button.

        Debug.Log(DefaultArea.activeInHierarchy);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DefaultArea.SetActive(false);
            Debug.Log(DefaultArea.activeInHierarchy);
            Instantiate(Token, (SelectedArea_1Postion + new Vector3(0f, 3.12f, 0f)), Quaternion.identity);
        }
    }
}