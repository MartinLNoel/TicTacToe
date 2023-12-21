using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public GameObject Switcher(GameObject currentToken, GameObject playerX, GameObject playerO)
    {
        GameObject newToken = currentToken;

        newToken = (newToken == playerX) ? playerO : playerX;

        return newToken;
    }
}
