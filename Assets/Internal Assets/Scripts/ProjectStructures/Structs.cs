using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structs
{
    [System.Serializable]
    public struct PlayerCardSlot
    {
        [SerializeField] CardAbility[] ability;
        [SerializeField] GameValueRequire[] require_to_unlock;
        [SerializeField] bool is_unlock;
        public bool IsUnlock
        {
            get
            {
                return is_unlock;
            }
        }
        public void UseAbility(int num)
        {
            if (num >= 0 && num < ability.Length)
                ability[num].UseAbility();
        }
        public void UseAbility()
        {
            foreach (CardAbility c_a in ability)
                c_a.UseAbility();
        }
    }
    [System.Serializable]
    public struct GameValueRequire
    {
        [SerializeField] Enums.GameValueType value_type;
        [SerializeField] Enums.Technology technology;
        [SerializeField] Enums.Resources resources;
        [SerializeField] int count;

        public Enums.Technology Technology
        {
            get
            {
                if (value_type == Enums.GameValueType.Technology)
                    return technology;
                else return Enums.Technology.None;
            }
        }
        public Enums.Resources Resources
        {
            get
            {
                if (value_type == Enums.GameValueType.Science)
                    return resources;
                else return Enums.Resources.None;
            }
        }
        public Enums.GameValueType ValueType
        {
            get
            {
                return value_type;
            }
        }
        public int Count
        {
            get
            {
                if (value_type != Enums.GameValueType.Technology && value_type != Enums.GameValueType.Resource)
                    return count;
                else return -1;
            }
        }
    }
}