using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleStat
{
    //public ModuleType type;
    public string Name;
    public float Value;
    public float MaxValue;

    public ModuleStat(string name, float value, float maxValue )
    {
        Name = name;
        Value = value;
        MaxValue = maxValue;
    }
}
