using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Card : MonoBehaviour
{
    [SerializeField] ScriptableCard card_data;
    CardSpriteLinker sprite_linker;
    public ScriptableCard CardData
    {
        get
        {
            return card_data;
        }
    }
    public CardSpriteLinker  SpriteLinker
    {
        get
        {
            return sprite_linker;
        }
    }
    private void Awake()
    {
        sprite_linker = GetComponent<CardSpriteLinker>();
    }
    //Every tick using. Need to do Generating only after changing.
    //Maybe should check prev version and curent, or do modifier in property
    private void OnDrawGizmos()  //Editor Card Generator.  
    {
        GenerateFromData();
    }
    public void GenerateFromData() //Finish the method
    {
        GetComponent<CardSpriteLinker>().GenerateSpriteFromData(card_data.CardFrontSide, card_data.CardBackSide);
    }
    void Start()
    {
        GenerateFromData();
    }
}
