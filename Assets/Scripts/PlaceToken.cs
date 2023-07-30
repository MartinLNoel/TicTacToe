using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceToken : MonoBehaviour
{
    public GameObject Token;
    public GameObject SelectedArea;

    // Update is called once per frame
    void Update()
    {
        Vector3 SelectedArea_1Postion = SelectedArea.transform.position;
        //To-DO: Make it so that when you press a button it counts up words. So that you can change where you want to place it with pressing one button.

        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(Token, SelectedArea_1Postion, Quaternion.identity);
    }
}