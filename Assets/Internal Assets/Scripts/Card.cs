using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] ScriptableCard card_data;
    [SerializeField] GameObject front_sprite;
    [SerializeField] GameObject back_sprite;

    [ExecuteInEditMode]
    private void OnDrawGizmos()  //Editor Card Generator.
    {
        GenerateFromData();
    }
    public ScriptableCard GetCardData
    {
        get
        {
            return card_data;
        }
    }
    public void GenerateFromData()
    {
        front_sprite.GetComponent<SpriteRenderer>().sprite = card_data.CardFrontSide;
        back_sprite.GetComponent<SpriteRenderer>().sprite = card_data.CardBackSide;
    }

    void Start()
    {
        GenerateFromData();
    }

    void Update()
    {
        
    }
}
