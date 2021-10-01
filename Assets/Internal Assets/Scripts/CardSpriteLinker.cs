using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpriteLinker : MonoBehaviour
{
    [SerializeField] GameObject front_sprite;
    [SerializeField] GameObject back_sprite;
    public void GenerateSpriteFromData(Sprite front, Sprite back)
    {
        front_sprite.GetComponent<SpriteRenderer>().sprite = front;
        back_sprite.GetComponent<SpriteRenderer>().sprite = back;
    }
}
