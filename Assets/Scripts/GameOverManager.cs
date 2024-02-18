using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public string newText = "Null";

    private void Start()
    {

        textMeshProUGUI.text = newText;
    }

    public void ChangeGameOverTitle(string newTitle)
    {
        newText = newTitle;
    }
}
