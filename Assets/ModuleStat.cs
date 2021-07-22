using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ModuleStatType { Null , POWER = 0, ENERGY, DAMAGE, LIFESPAN, EFFICIENCY  }
public class ModuleStat
{
    //public ModuleType type;
    public ModuleStatType Type;
    public string Name;
    public float Value;
    public float MaxValue;

    public ModuleStat(ModuleStatType type, string name, float value, float maxValue )
    {
        Type = type;
        Name = name;
        Value = value;
        MaxValue = maxValue;
    }
}
