using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        //ChangeGameOverTitle("DRAW");
        Debug.Log(textMeshProUGUI);
        //textMeshProUGUI.text = "GameOver";
        Debug.Log(textMeshProUGUI);
    }

    public void ChangeGameOverTitle(string newText)
    {
        textMeshProUGUI.text = newText;
    }
}
