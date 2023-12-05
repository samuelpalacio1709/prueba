using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Image pickableImage;
    private Transform parent;
    public DropZone dropZone =null;

    public void SetItem(ItemSO item)
    {
        pickableImage.sprite = item.mainSprite;
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
             
    }


}
