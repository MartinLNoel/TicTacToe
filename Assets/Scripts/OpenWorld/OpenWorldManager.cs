using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenWorldManager : MonoBehaviour
{
    public bool isThereNotification = false;

    [SerializeField]
    private SceneAsset notificationLoadsScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isThereNotification)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(notificationLoadsScene.name);
            }
        }
    }
}
