using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TokenClones : MonoBehaviour
{
    private List<GameObject> prefabClones = new List<GameObject>();

    public void SpawnClone(Vector3 playerPositon, GameObject currentToken)
    {
        GameObject clone = Instantiate(currentToken, (playerPositon + new Vector3(0f, 3.12f, 0f)), Quaternion.identity);
        prefabClones.Add(clone); // Store the reference to the clone
    }
    public void DeleteClone(Vector3 playerPositon)
    {
        // Destroy(prefabClones.Find(clone => clone.transform.position == targetPosition + new Vector3(0f, 3.12f, 0f)));
        
        GameObject cloneToDelete = null;

        int count = 0;
        foreach (GameObject clone in prefabClones)
        {
            Debug.Log($"Count: {count}");
            count++;
            Debug.Log($"playerPositon: {playerPositon}");
            Debug.Log($"clone.transform.position: {clone.transform.position}");
            if (clone.transform.position == playerPositon)
            {
                Debug.Log("Found the clone to delete");
                cloneToDelete = clone;
                break; // Stop searching once the clone is found
            }
        }

        // Destroy the clone if it's found
        if (cloneToDelete != null)
        {
            Debug.Log("Destroying the clone");
            Destroy(cloneToDelete);
            prefabClones.Remove(cloneToDelete); // Optionally remove it from the list
        }
    }
}
