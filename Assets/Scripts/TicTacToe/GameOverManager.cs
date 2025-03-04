using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private DataStorage dataStorage;

    public TextMeshProUGUI textMeshProUGUI;



    private void Start()
    {
        dataStorage = FindObjectOfType<DataStorage>();
        //Debug.Log($"after load2: {dataStorage.DisplayGameOverTitle()}");

        //string resultText = dataStorage.DisplayGameOverTitle();
        //Debug.Log($"After variable: {dataStorage.DisplayGameOverTitle()}");
        //Debug.Log($"variable: {resultText}");

        textMeshProUGUI.text = DataStorage.Instance.DisplayGameOverTitle();
    }
}
