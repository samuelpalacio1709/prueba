using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public ItemSO.type type;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Image pickableImage;
    private Transform parent;
    public Transform dropZone =null;
    public bool isTaken;

    public void SetItem(ItemSO item)
    {
        isTaken = true;
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

        Vector3 mousePos = Mouse.current.position.ReadValue();

        transform.position = mousePos;

        //if (isTaken)
        //{
        //    Vector3 mousePos = Mouse.current.position.ReadValue();

        //    transform.position = mousePos;
        //}
    }
        

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dropZone)
        {
            transform.SetParent(dropZone);

        }
        else
        {
            transform.SetParent(parent);

        }
        pickableImage.raycastTarget = true;

    }


}
