using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Ability/Value/Choose/Resource")]
public class ChooseResource : CardAbility, ICardAbility
{
    [SerializeField] Enums.Resources[] resources_choose;
    public override void UseAbility()
    {
        
    }
    public override int CheckAbilityTurn() //Доработать
    {
        return -1;
    }
}
