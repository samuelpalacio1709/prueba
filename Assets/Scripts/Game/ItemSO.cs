using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public type itemType;
    public string id;
    public int position = -1;
    public bool isWeared;
    public Sprite mainSprite;
    public Sprite[] upSprites;
    public Sprite[] forwardSprites;
    public Sprite[] rightSprites;
    public Sprite[] leftSprites;
    public Action OnWeared;
    public enum type
    {
        Head,
        Cheast,
        Legs,
        Hands,
        Feet,
        Any
    }
    public void WearItem()
    {
        OnWeared?.Invoke();
    }
    public void Clear()
    {
        position = -1;
        isWeared=false;
        id = this.name;
    }
}
