using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Image pickableImage;
    private Transform parent;
    public DropZone dropZone =null;
    public DropZone savedDropZone;
    private ItemSO item;

    public static Action<ItemSO> onItemWeared;
    public static Action<Draggable> onItemUnWeared;


    public void WearItem()
    {
        if (item != null)
        {
            onItemWeared?.Invoke(item);

        }
    }
    public void OnDrop()
    {
        if (item != null)
        {
            onItemUnWeared?.Invoke(this);

        }
        if (dropZone)
        {
            if (GetItemType() == dropZone.type)
            {
                WearItem();
            }
        }
       
    }

    public ItemSO GetItem()
    {
        return this.item;
    }

    public void PlaceInSavedZone()
    {
        transform.SetParent(savedDropZone.transform);

    }

    public void SetItem(ItemSO item)
    {
        this.item = item;
        pickableImage.sprite = item.mainSprite;
    }
    public ItemSO.type GetItemType()
    {
        return item.itemType;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
            parent = transform.parent;
            Vector3 mousePos = Mouse.current.position.ReadValue();
            transform.position = mousePos;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            pickableImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
            Vector3 mousepos = Mouse.current.position.ReadValue();
            transform.position = mousepos;
        
    }


    public void OnEndDrag(PointerEventData eventData)
    {

            if (dropZone)
            {
                if (!dropZone.hasElement)
                {
                    transform.SetParent(dropZone.transform);
                }
               
            }
            else
            {
                transform.SetParent(parent);

            }
            pickableImage.raycastTarget = true;

        OnDrop();
    }

    public void SetDropZone(DropZone dropzone)
    {
        this.dropZone = dropzone;
    }

}
