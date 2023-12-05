using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] InventorySO inventory;
    [SerializeField] GameObject inventorySceen;
    private Draggable[] draggables;

    private void Awake()
    {
        SetUpDraggables();
    }
    private void OnEnable()
    {
        inventory.OnNewItem += UpdateItem;
    }
    private void OnDisable()
    {
        inventory.OnNewItem -= UpdateItem;

    }
    private void SetUpDraggables()
    {
        inventorySceen.SetActive(true);
        draggables = GetComponentsInChildren<Draggable>();
        inventorySceen.SetActive(false);
    }
    private void UpdateItem(ItemSO item)
    {
        for (int i = 0; i < draggables.Length; i++)
        {
            if (!draggables[i].isTaken)
            {
                draggables[i].SetItem(item);
                break;
            }
        }
    }

    public void ChangeInventoryScreen(bool state)
    {
        inventorySceen.SetActive(state);
    }
}
