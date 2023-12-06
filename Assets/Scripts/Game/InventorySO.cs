using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();
    public List<ItemSO> allItems = new List<ItemSO>();
    public Action<ItemSO> OnNewItem;
    public ItemSO currentHeadItem;
    public ItemSO currentCheastItem;
    public ItemSO currentLegsItem;
    public ItemSO currentFeetItem;
    public ItemSO currentHandsItem;

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
               return currentHeadItem;
            case ItemSO.type.Cheast:
                return currentCheastItem;
            case ItemSO.type.Legs:
                return currentLegsItem;
            case ItemSO.type.Hands:
                return currentHandsItem;
            case ItemSO.type.Feet:
                return currentFeetItem;
        }
        return null;
    }

    public ItemSO GetItemByName(string name)
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            if (allItems[i].name == name)
            {
                return allItems[i];
            }
        }

        return null;
    }

    public bool CheckIfItemIsWeared(ItemSO item)
    {
        ItemSO[] validItems = { currentHeadItem ,
                                currentCheastItem , 
                                currentLegsItem,
                                currentHandsItem, 
                                currentFeetItem };

        
        return (validItems.Contains(item));
       
    }

    public void Clear()
    {
        items.Clear();
        foreach (var item in allItems)
        {
            item.Clear();
        }
        currentHeadItem = null;
        currentCheastItem = null;
        currentLegsItem = null;
        currentHandsItem = null;
        currentFeetItem = null;

    }


}
