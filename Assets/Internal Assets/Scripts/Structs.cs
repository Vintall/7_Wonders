using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structs
{
    [System.Serializable]
    public struct PlayerCardSlot
    {
        [Range(0, 5), SerializeField] int war_points;
        [Range(0, 5), SerializeField] int coins;
        [SerializeField] CardAbility ability;

        public void UseAbility()
        {
            ability.UseAbility();
        }
    }
}