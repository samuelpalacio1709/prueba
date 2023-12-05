using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hasElement => transform.childCount > 0;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Draggable dragabble = null;
        eventData.pointerDrag?.TryGetComponent(out dragabble);
        if (dragabble != null && transform.childCount<1)
        {
            dragabble.dropZone = this;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        Draggable dragabble=null;
        eventData.pointerDrag?.TryGetComponent(out dragabble);

        if (dragabble != null)
        {
            dragabble.dropZone = null;
        }
    }
}
