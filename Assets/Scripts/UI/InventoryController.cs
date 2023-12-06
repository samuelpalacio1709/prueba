using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryController : Singleton<InventoryController>
{
    [SerializeField] public InventorySO inventory;
    [SerializeField] private GameObject inventorySceen;
    [SerializeField] private GameObject draggableObject;
    [SerializeField] private GameObject dropZonesGroup;
    private DropZone[] dropZones;
    private List<Draggable> draggables = new List<Draggable>();
    private DataManager dataManager => DataManager.Instance;
    private CharacterClothesController characterClothes => CharacterClothesController.Instance;

    [SerializeField]  private DropZone headClothSlot;
    [SerializeField]  private DropZone cheastClothSlot;
    [SerializeField]  private DropZone legsClothSlot;
    [SerializeField]  private DropZone feetClothSlot;
    [SerializeField]  private DropZone handsClothSlot;
    

    public static Action<InventorySO> OnInventoryClose;
    private void Awake()
    {
        SetUpDropZones();
        SetUpInventoryData();

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

    private void SetUpInventoryData()
    {
        inventory.Clear();
        

        var savedWearables = dataManager.user?.inventory?.wearables;
        for (int i = 0; i < savedWearables?.Length; i++)
        {
            ItemSO item = inventory.GetItemByName(savedWearables[i].id);
            item.position = savedWearables[i].position;
            item.isWeared = savedWearables[i].isWeared;
            inventory.items.Add(item);
            UpdateItem(item);
        }
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
                    int position =  item.position!=-1 ? item.position : i;
                    Debug.Log(item.position);
                    draggable.savedDropZone = dropZones[position];
                    draggable.dropZone = dropZones[position];
                 
                    draggable.GetItem().position = position;

                    if (item.isWeared)
                    {
                        var zone = GetDropZoneByType(draggable.GetItemType());
                        draggable.savedDropZone = zone;
                        draggable.dropZone = zone;
                        draggable.GetItem().position = -1;
                        var clothSlot = characterClothes.GetSlotByType(draggable.GetItemType());
                        clothSlot.WearItem(draggable.GetItem());
                    }
                    draggables.Add(draggable);
                    draggable.PlaceInSavedZone();
                    SaveSlots();
                    SaveUser();
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
            item.savedDropZone = item.GetComponentInParent<DropZone>();
            int index= Array.IndexOf(dropZones, item.savedDropZone);
            item.GetItem().position = index;
        }

        SaveSlots();
        SaveUser();

    }
    private void SaveSlots()
    {
        inventory.currentHeadItem = GetCloth(headClothSlot);
        inventory.currentFeetItem = GetCloth(feetClothSlot);
        inventory.currentCheastItem = GetCloth(cheastClothSlot);
        inventory.currentHandsItem = GetCloth(handsClothSlot);
        inventory.currentLegsItem = GetCloth(legsClothSlot);
    }

    private ItemSO GetCloth(DropZone zone)
    {
        if (zone.hasElement)
        {
            return zone.GetComponentInChildren<Draggable>().GetItem();
        }
        return null;
    }

    private void SaveUser()
    {
        User user = dataManager.AllUsers[dataManager.user.username];
        SaveInventory(user);
        dataManager.SaveUsersInFile();
    }

    public void SaveInventory(User user)
    {
        if (user == null) return;
        List<PlayerWearable> wearables = new List<PlayerWearable>();
        foreach (var item in inventory.items)
        {
            PlayerWearable playerWearable = new PlayerWearable(item.id,
                item.position,
                inventory.CheckIfItemIsWeared(item));
            wearables.Add(playerWearable);

            Debug.Log($"The one to be saved is {item.position}");
        }
        if (wearables.Count > 0)
        {
            
            user.inventory = new PlayerInventory();
            user.inventory.wearables = new PlayerWearable [] { };

            user.inventory.wearables = wearables.ToArray();
        }
    }

    public DropZone GetDropZoneByType(ItemSO.type type)
    {
        switch (type)
        {
            case ItemSO.type.Head:
                return headClothSlot;
            case ItemSO.type.Cheast:
                return cheastClothSlot;
            case ItemSO.type.Legs:
                return legsClothSlot;
            case ItemSO.type.Hands:
                return handsClothSlot;
            case ItemSO.type.Feet:
                return feetClothSlot;
        }
        return null;
    }
}
