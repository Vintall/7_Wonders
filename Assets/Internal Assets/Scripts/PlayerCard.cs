using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    [SerializeField] ScriptablePlayerCard data;
    [SerializeField] GameObject sprite;
    public void GenerateFromData()
    {
        sprite.GetComponent<SpriteRenderer>().sprite = data.Sprite;
    }
    private void Start()
    {
        
    }
}
