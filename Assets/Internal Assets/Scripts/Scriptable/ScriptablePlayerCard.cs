using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/PlayerCard", fileName = "PlayerCard")]
public class ScriptablePlayerCard : ScriptableObject
{
    [SerializeField] string card_name;
    [SerializeField] Sprite sprite;
    [SerializeField] Structs.PlayerCardSlot[] slot;
    
    public Structs.PlayerCardSlot[] Slots
    {
        get
        {
            return slot;
        }
    }
    public string CardName
    {
        get
        {
            return card_name;
        }
    }
    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }
}
