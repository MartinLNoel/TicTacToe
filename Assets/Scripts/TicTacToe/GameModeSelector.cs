using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeSelector : MonoBehaviour
{
    public Button buttonClassic;
    public Button buttonRoman;
    public Button buttonExit;

    public SceneAsset gameModeClassic;
    public SceneAsset gameModeRoman;

    private void Start()
    {
        // Assign button click listeners
        buttonClassic.onClick.AddListener(() => OnbuttonClassicClick());
        buttonRoman.onClick.AddListener(() => OnbuttonRomanClick());
        buttonExit.onClick.AddListener(() => OnbuttonExitClick());
    
    }

    void OnbuttonClassicClick()
    {
        SceneManager.LoadScene(gameModeClassic.name);
    }
    
    void OnbuttonRomanClick()
    {
        SceneManager.LoadScene(gameModeRoman.name);
    }

    void OnbuttonExitClick()
    {
        Debug.Log("Exit button clicked");
        Application.Quit();
    }
}