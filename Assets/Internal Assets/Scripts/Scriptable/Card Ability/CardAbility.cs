using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbility : ScriptableObject, ICardAbility
{
    [SerializeField] Sprite sprite;
    [SerializeField] Enums.AbilityUseTime ability_use_time;
    public Enums.AbilityUseTime AbilityTimeUse
    {
        get
        {
            return ability_use_time;
        }
    }
    public virtual void UseAbility()
    {

    }
    public virtual int CheckAbilityTurn()
    {
        return -1;
    }
}
