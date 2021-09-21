using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAbility : CardAbility, ICardAbility
{
    public override void UseAbility()
    {
        Debug.Log("TestAbility was used");
    }
    public override int CheckAbilityTurn()
    {
        return 0;
    }
}