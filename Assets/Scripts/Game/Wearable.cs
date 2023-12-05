using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wearable : MonoBehaviour , IInteractable
{

    [SerializeField] string messageToInteract = "";
    [SerializeField] ItemSO item;
    [SerializeField] InventorySO inventory;
    private UIController UIController => UIController.Instance;

    public void HideInteraction()
    {
        UIController.ChangeToastMessage("", false);
    }

    public void Interact()
    {
        UIController.ChangeToastMessage("", false);
        inventory.AddItem(item);
        gameObject.SetActive(false);

    }

    public void ShowInteraction()
    {
        UIController.ChangeToastMessage(messageToInteract, true);
    }

    
}
