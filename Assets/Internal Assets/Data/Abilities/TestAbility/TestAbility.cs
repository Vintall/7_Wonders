using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "TestAbility")]
public class TestAbility : PlayerCardAbility, IPlayerCardAbility
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
