using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/PlayerCardAbility")]
public class PlayerCardAbility: ScriptableObject, IPlayerCardAbility
{
    [SerializeField] Sprite sprite;

    public virtual void UseAbility()
    {

    }
    public virtual int CheckAbilityTurn()
    {
        return -1;
    }
}
