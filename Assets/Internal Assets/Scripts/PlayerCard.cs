using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    [SerializeField] ScriptablePlayerCard data;
    [SerializeField] GameObject sprite;
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
            if (transform.GetChild(i).gameObject.name == "Sprite")
            {
                sprite = transform.GetChild(i).gameObject;
                break;
            }
    }
    public void GenerateFromData()
    {
        sprite.GetComponent<SpriteRenderer>().sprite = data.Sprite;
    }
    [ExecuteInEditMode]
    private void OnDrawGizmos()  //Editor Card Generator
    {
        GenerateFromData();
    }
    private void Start()
    {
        
    }
}
