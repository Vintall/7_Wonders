using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] CardData card_data;
    [SerializeField] TechnologyData technology_data;
    
    public static GameData instance;

    public CardData CardData
    {
        get
        {
            return card_data;
        }
    }

    public ScriptableTechnology GetTechnology(string name) 
    {
        return technology_data.DataElement(name);
    }
    public ScriptableTechnology GetTechnology(int num)
    {
        return technology_data.DataElement(num);
    }
    public TechnologyData TechnologyData
    {
        get
        {
            return technology_data;
        }
    }
    private void Awake()
    {
        instance = this; //Singleton 
    }
}
