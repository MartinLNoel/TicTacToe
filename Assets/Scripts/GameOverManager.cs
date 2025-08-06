using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private DataStorage dataStorage;

    public TextMeshProUGUI textMeshProUGUI;



    private void Start()
    {
        dataStorage = FindObjectOfType<DataStorage>();
        textMeshProUGUI.text = DataStorage.Instance.DisplayGameOverTitle();
    }
}
