using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wearable : MonoBehaviour , IInteractable
{

    [SerializeField] string messageToInteract = "";
    [SerializeField] InventorySO inventory;
    [SerializeField] SpriteRenderer spriteRenderer;
    private UIController UIController => UIController.Instance;

    ItemSO item;

    public void SetItem(ItemSO item)
    {
        this.item = item;
        spriteRenderer.sprite = item.mainSprite;
    }

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
