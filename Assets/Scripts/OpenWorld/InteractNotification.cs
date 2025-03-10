using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNotification : MonoBehaviour
{
    public GameObject Trigger;
    private OpenWorldManager openWorldManager;
   
    // Start is called before the first frame update
    void Start()
    {
        openWorldManager = FindObjectOfType<OpenWorldManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Trigger.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Trigger.SetActive(false);
        openWorldManager.isThereNotification = false;
    }

    private void OnTriggerStay(Collider other)
    {
        openWorldManager.isThereNotification = true;
    }


}
