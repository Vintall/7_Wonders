using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] ScriptableCard card_data;
    GameObject front_sprite;
    GameObject back_sprite;

    private void Awake()
    {
        front_sprite = transform.GetChild(0).gameObject;
        back_sprite = transform.GetChild(1).gameObject;
    }

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
}
