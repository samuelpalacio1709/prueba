using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractablesHandler : MonoBehaviour
{


    private IInteractable currentInteractable;


    private void OnEnable()
    {
        InputHandler.OnInputInteraction += InteractWithObject;

    }
    private void OnDisable()
    {
        InputHandler.OnInputInteraction -= InteractWithObject;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable;
        collision.gameObject.TryGetComponent(out interactable);
        if (interactable != null)
        {
            currentInteractable= interactable;
            interactable.ShowInteraction();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable;
        collision.gameObject.TryGetComponent(out interactable);
        if (interactable != null)
        {
            interactable.HideInteraction();
            currentInteractable = null;

        }

    }

    private void InteractWithObject()
    {
        if(currentInteractable!=null)
        {
            currentInteractable.Interact();
            currentInteractable = null;
        }
    }
}
