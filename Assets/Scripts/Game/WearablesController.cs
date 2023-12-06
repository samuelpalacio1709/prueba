using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearablesController : MonoBehaviour
{
    [SerializeField] InventorySO inventory;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject spawnObjectWearable;

    private void Start() => SpawnObjects();

    public void SpawnObjects()
    {
        for (int i = 0; i < inventory.allItems.Count; i++)
        {
            if(spawnPoint.GetChild(i) != null)
            {
                if (inventory.items.Contains(inventory.allItems[i])){
                    continue;
                }
                var wearable = Instantiate(spawnObjectWearable, spawnPoint.GetChild(i));
                wearable.GetComponent<Wearable>().SetItem(inventory.allItems[i]);
            }
            
        }
    }
}
