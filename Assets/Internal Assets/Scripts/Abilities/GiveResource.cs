using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Ability/Value/Give/Resource")]
public class GiveResource : CardAbility, ICardAbility
{
    [SerializeField] Enums.Resources resource;
    public override void UseAbility()
    {

    }
    public override int CheckAbilityTurn()
    {
        return -1;
    }
}
