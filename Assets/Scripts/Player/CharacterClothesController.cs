using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClothesController : Singleton<CharacterClothesController>
{
    [SerializeField] private CharacterClothSlot head;
    [SerializeField] private CharacterClothSlot cheast;
    [SerializeField] private CharacterClothSlot hands;
    [SerializeField] private CharacterClothSlot legs;
    [SerializeField] private CharacterClothSlot feet;



    public CharacterClothSlot GetSlotByType(ItemSO.type type)
    {
        switch (type)
        {
            case ItemSO.type.Head:
                return head;
            case ItemSO.type.Cheast:
                return cheast;
            case ItemSO.type.Hands:
                return hands;
            case ItemSO.type.Legs:
                return legs;
            case ItemSO.type.Feet:
                return feet;
        }
        return null;
    }
}
