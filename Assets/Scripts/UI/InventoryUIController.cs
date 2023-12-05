using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] InventorySO inventory;
    [SerializeField] GameObject inventorySceen;
    [SerializeField] GameObject draggableObject;
    [SerializeField] GameObject dropZonesGroup;
    private List<Draggable> draggables = new List<Draggable>();
    private DropZone[] dropZones;


    private void Awake()
    {
        SetUpDropZones();
    }
    private void OnEnable()
    {
        inventory.OnNewItem += UpdateItem;
    }
    private void OnDisable()
    {
        inventory.OnNewItem -= UpdateItem;

    }
    private void SetUpDropZones()
    {
        inventorySceen.SetActive(true);
        dropZones = dropZonesGroup.GetComponentsInChildren<DropZone>();
        inventorySceen.SetActive(false);
    }
    private void UpdateItem(ItemSO item)
    {
        for (int i = 0; i < dropZones.Length; i++)
        {

            if (!dropZones[i].hasElement)
            {
                var draggableElement = Instantiate(draggableObject, dropZones[i].transform);
                Draggable draggable;
                draggableElement.TryGetComponent(out draggable);
                if (draggable != null)
                {
                    draggable.SetItem(item);
                    break;
                }
            }
        }
    }

    public void ChangeInventoryScreen(bool state)
    {
        inventorySceen.SetActive(state);
    }
}
