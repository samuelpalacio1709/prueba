using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public type itemType;
    public string name;
    public string path;
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
        Hand,
        Foot
    }
    public void WearItem()
    {
        OnWeared?.Invoke();
    }
}
