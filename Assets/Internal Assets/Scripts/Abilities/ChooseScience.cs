using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Ability/Value/Choose/Science")]
public class ChooseScience : CardAbility, ICardAbility
{
    [SerializeField] Enums.Science[] science_choose;
    public override void UseAbility()
    {

    }
    public override int CheckAbilityTurn() //Доработать
    {
        return -1;
    }
}
