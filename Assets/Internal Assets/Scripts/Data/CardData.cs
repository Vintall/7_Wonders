using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    [SerializeField] List<ScriptableCard> cards;
    public List<ScriptableCard> Cards
    {
        get
        {
            return cards;
        }
    }
    private void Awake()
    {
        for (byte i = 0; i < cards.Count; i++)
        {
            cards[i].ID = i;
        }
    }
    void Start()
    {
        
    }
    //asd
    // Update is called once per frame
    void Update()
    {
        
    }
}
