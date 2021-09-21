using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    public enum Age
    {
        First_age,
        Second_age,
        Third_age
    }
    public enum CardType
    {
        Gray,
        Brown,
        Green,
        Red,
        Yellow,
        Blue,
        Purple
    }
    public enum Technology
    {
        None = -1,
        Astronomy = 0,
        Barrel = 1,
        Beacon = 2,
        Book = 3,
        Bowl = 4,
        Camel = 5,   
        Canopy = 6,  
        Castle = 7,
        Electricity = 8,
        Entertainment = 9,
        Feather = 10,
        Government = 11,
        Hammer = 12,
        Harp = 13,
        Horseshoe = 14,
        Kettle = 15,
        Priest = 16,
        Saw = 17,
        Scales = 18,
        Scroll = 19,
        Target = 20,
        Torch = 21,
        Water = 22,
        Сavalry = 23
    }
    public enum Resources
    {
        None,
        Wood,
        Stone,
        Brick,
        Ore,
        Glass,
        Paper,
        Silk
    }
    public enum Science
    {
        None,
        Engineering,
        Chronicle,
        Geometry
    }
    public enum GameValueType
    {
        None,
        Coin,
        Technology,
        WarPoint,
        WictoryPoint,
        Science,
        Resource
    }
    public enum AbilityUseTime
    {
        None,
        StartAge,
        EndAge,
        EveryTurn,
        OnBuy
    }
}
