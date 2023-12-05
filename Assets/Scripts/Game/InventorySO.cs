using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();
    public Action<ItemSO> OnNewItem;
    public ItemSO currentHeadITem;
    public ItemSO currentCheastITem;
    public ItemSO currentLegsITem;
    public ItemSO currentFeetITem;

    public void AddItem(ItemSO item)
    {
        items.Add(item);
        OnNewItem?.Invoke(item);
    }
}
