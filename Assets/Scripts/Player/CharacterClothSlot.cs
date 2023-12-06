using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteAnimator))]
public class CharacterClothSlot : MonoBehaviour
{
    [SerializeField] ItemSO.type type;
    SpriteAnimator spriteAnimator => GetComponent<SpriteAnimator>();
    private ItemSO item;
    

    
    private void OnEnable()
    {
        Draggable.onItemWeared += WearItem;
        Draggable.onItemUnWeared += UnWearItem;
        InventoryController.OnInventoryClose += ChangeClothes;

    }
    private void OnDisable()
    {
        Draggable.onItemWeared -= WearItem;
        Draggable.onItemUnWeared -= UnWearItem;
        InventoryController.OnInventoryClose -= ChangeClothes;
    }

    public void ChangeClothes(InventorySO inventory)
    {
        ItemSO currentItem =inventory.GetItemByType(type);
        SetItemSprites(currentItem);

    }

    public void WearItem(ItemSO item)
    {
        if (item.itemType == type)
        {
            this.item = item;
            SetItemSprites(item);
        }
    }

    public void SetItemSprites(ItemSO item)
    {
        if (item != null)
        {
            spriteAnimator.SetSprites(item.upSprites, item.forwardSprites,
                       item.rightSprites, item.leftSprites);
        }
        else
        {
            spriteAnimator.ClearSprites();

        }

    }

    public void UnWearItem(Draggable draggable)
    {
        var itemDraggable = draggable.GetItem();

        if (itemDraggable.itemType == type)
        {
           if(itemDraggable == this.item)
            {
                if (draggable.dropZone?.type == ItemSO.type.Any)
                {
                    this.item = null;
                    spriteAnimator.ClearSprites();
                }
                
            }

        }

    }
}
