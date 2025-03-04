 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// A script that saves the winner from GameManager to GameOverManager.
public class DataStorage : MonoBehaviour
{
    string resultText;

    // Singleton instance
    private static DataStorage instance;

    // Property to access the instance
    public static DataStorage Instance
    {
        get { return instance; }
    }

    // Awake is called before Start
    void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set this as the instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this
            Destroy(gameObject);
        }
    }


    public void ChangeGameOverTitle(string newText)
    {
        //Debug.Log($"NewText: {newText}");
        //Debug.Log($"resultText before assigned: {resultText}");

        resultText = newText;

        //Debug.Log($"resultText after assigned: {resultText}");
    }
    public string DisplayGameOverTitle()
    {
        //Debug.Log($"New function: {resultText}");
        return resultText;
    }

}
