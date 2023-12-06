using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hasElement => transform.childCount > 0;
    public ItemSO.type type;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Draggable dragabble = null;
        eventData.pointerDrag?.TryGetComponent(out dragabble);
        if (dragabble != null && transform.childCount<1)
        {
            if(dragabble.GetItemType()== this.type || this.type == ItemSO.type.Any)
            {
                dragabble.SetDropZone(this);
            }
            

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        Draggable dragabble=null;
        eventData.pointerDrag?.TryGetComponent(out dragabble);

        if (dragabble != null)
        {
            if (dragabble.GetItemType() == this.type || this.type == ItemSO.type.Any)
            {
                dragabble.SetDropZone(null);
            }
        }
    }
}
