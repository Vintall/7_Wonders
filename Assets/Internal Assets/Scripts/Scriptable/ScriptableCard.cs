using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Scriptable Card", fileName = "Scriptable Card")]
public class ScriptableCard : ScriptableObject
{
    [SerializeField] Sprite card_front_side;
    [SerializeField] Sprite card_back_side; //Нужен ли back side, если я уже определяю эпоху карты.

    byte id; // from 0 to 255
    [SerializeField] Enums.Age age;
    [SerializeField] Enums.CardType type;
    [SerializeField] int num_of_player;
    [SerializeField] string card_name;
    [SerializeField] Structs.GameValueRequire[] require;  //Сокрыть ненужные поля в GameValueRequire для Inspector
    [SerializeField] CardAbility[] ability;
    
    public byte ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public string Name
    {
        get
        {
            return card_name;
        }
    }
    public Sprite CardFrontSide
    {
        get
        {
            return card_front_side;
        }
    }
    public Sprite CardBackSide
    {
        get
        {
            return card_back_side;
        }
    }
    public Enums.Age Age
    {
        get
        {
            return age;
        }
    }
    public Enums.CardType Type
    {
        get
        {
            return type;
        }
    }
    public int NumOfPlayers
    {
        get
        {
            return num_of_player;
        }
    }
}