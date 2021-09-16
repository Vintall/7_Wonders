using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Scriptable Technology", fileName = "Scriptable Technology")]
public class ScriptableTechnology : ScriptableObject
{
    [SerializeField] string technology_name;
    [SerializeField] Sprite sprite;
    public string Name
    {
        get
        {
            return technology_name;
        }
    }
    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }
}
