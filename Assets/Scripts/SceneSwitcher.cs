using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//A script dedicated to swith Scenes

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    private SceneAsset sceneToLoad;

    private void Start()
    {
        // Add a click event to the UI button
        if (TryGetComponent<Button>(out var button))
        {
            button.onClick.AddListener(LoadAssignedScene);
        }
        else
        {
            Debug.LogWarning("No Button component found on GameObject!");
        }
    }

    // Function to load the assigned scene
    public void LoadAssignedScene()
    {
        if (sceneToLoad != null)
        {
            SceneManager.LoadScene(sceneToLoad.name);
        }
        else
        {
            Debug.LogWarning("Scene is not assigned to the SceneSwitcher!");
        }
    }
}
