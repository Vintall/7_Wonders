using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Ability/Value/Give/Technology")]
public class GiveTechnology : CardAbility, ICardAbility
{
    [SerializeField] Enums.Technology[] technology;
    public override void UseAbility()
    {
        
    }
    public override int CheckAbilityTurn()
    {
        return -1;
    }
}
