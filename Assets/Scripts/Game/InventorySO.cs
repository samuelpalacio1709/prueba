using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();
    public List<ItemSO> allItems = new List<ItemSO>();
    public Action<ItemSO> OnNewItem;
    public ItemSO currentHeadITem;
    public ItemSO currentCheastITem;
    public ItemSO currentLegsITem;
    public ItemSO currentFeetITem;
    public ItemSO currentHandsITem;

    public void AddItem(ItemSO item)
    {
        items.Add(item);
        OnNewItem?.Invoke(item);
    }

    public ItemSO GetItemByType(ItemSO.type type)
    {
        switch(type)
        {
            case ItemSO.type.Head:
               return currentHeadITem;
            case ItemSO.type.Cheast:
                return currentCheastITem;
            case ItemSO.type.Legs:
                return currentLegsITem;
            case ItemSO.type.Hands:
                return currentHandsITem;
            case ItemSO.type.Feet:
                return currentFeetITem;
        }
        return null;
    }
}
