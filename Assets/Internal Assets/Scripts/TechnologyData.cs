using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyData : MonoBehaviour
{
    [SerializeField] ScriptableTechnology[] data;
    public int GetDataLength
    {
        get
        {
            return data.Length;
        }
    }
    public ScriptableTechnology[] AllData
    {
        get
        {
            return data;
        }
    }
    public ScriptableTechnology DataElement(int num)
    {
        if (GetDataLength > num)
        {
            return AllData[num];
        }
        else 
            return null;
    }
    public ScriptableTechnology DataElement(string name)
    {
        foreach(ScriptableTechnology i in data)
        {
            if (i.Name == name)
                return i;
        }
        return null;
    }
}
