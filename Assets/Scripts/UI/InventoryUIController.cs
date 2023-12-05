using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] InventorySO inventory;
    [SerializeField] GameObject inventorySceen;
    [SerializeField] GameObject draggableObject;
    [SerializeField] GameObject dropZonesGroup;
    private DropZone[] dropZones;
    private List<Draggable> draggables = new List<Draggable>();

    [SerializeField]  private DropZone headClothSlot;
    [SerializeField]  private DropZone cheastClothSlot;
    [SerializeField]  private DropZone legsClothSlot;
    [SerializeField]  private DropZone feetClothSlot;
    [SerializeField]  private DropZone handsClothSlot;
    

    public static Action<InventorySO> OnInventoryClose;
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
                    draggable.savedDropZone = dropZones[i];
                    draggable.PlaceInSavedZone();
                    draggables.Add(draggable);
                    break;
                }
            }
        }
    }

    public void ChangeInventoryScreen(bool state)
    {
        inventorySceen.SetActive(state);
        if(state == false)
        {
            OnInventoryClose?.Invoke(inventory);
        }
        foreach (var item in draggables)
        {
            item.PlaceInSavedZone();
        }

    }

    public void SaveClothes()
    {

        foreach (var item in draggables)
        {
            item.savedDropZone = item.dropZone;
        }

        inventory.currentHeadITem = GetCloth(headClothSlot);
        inventory.currentFeetITem = GetCloth(feetClothSlot);
        inventory.currentCheastITem = GetCloth(cheastClothSlot);
        inventory.currentHandsITem = GetCloth(handsClothSlot);
        inventory.currentLegsITem = GetCloth(legsClothSlot);
    }

    private ItemSO GetCloth(DropZone zone)
    {
        if (zone.hasElement)
        {
            return zone.GetComponentInChildren<Draggable>().GetItem();
        }
        return null;
    }
}
