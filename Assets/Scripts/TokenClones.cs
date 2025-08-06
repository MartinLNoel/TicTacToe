using System.Collections.Generic;
using UnityEngine;

public class TokenClones : MonoBehaviour
{
    private List<GameObject> prefabClones = new();

    public void SpawnClone(UnityEngine.Vector3 playerPositon, GameObject currentToken)
    {
        GameObject clone = Instantiate(currentToken, (playerPositon + new UnityEngine.Vector3(0f, 3.12f, 0f)), UnityEngine.Quaternion.identity);

        prefabClones.Add(clone); // Store the reference to the clone
    }
    public void DeleteClone(UnityEngine.Vector3 playerPositon)
    {
        GameObject cloneToDelete = null;

        foreach (GameObject clone in prefabClones)
        {
            if (UnityEngine.Vector3.Distance(clone.transform.position, playerPositon) < 0.01)
            {
                cloneToDelete = clone;
                break; // Stop searching once the clone is found
            }
        }

        // Destroy the clone if it's found
        if (cloneToDelete != null)
        {
            Destroy(cloneToDelete);
            prefabClones.Remove(cloneToDelete); // Optionally remove it from the list
        }
    }
}
