using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    static UIController instance;
    [SerializeField] CardKitUI card_kit_ui;
    public static UIController Instance
    {
        get
        {
            return instance;
        }
    }
    public CardKitUI GetCardKitUi
    {
        get
        {
            return card_kit_ui;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
