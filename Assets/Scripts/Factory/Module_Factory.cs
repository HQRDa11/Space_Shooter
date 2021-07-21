using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Factory
{
    private int baseXPforLevelUp = 100; // Should be put in LevelData class CSTR

    private Sprite m_shield_sprite;
    private Sprite m_repairDrone_sprite;
    private Sprite m_turret_sprite;

    public Module_Factory()
    {
        m_shield_sprite      = Resources.Load<Sprite>("Sprites/Icons/Shield");
        m_repairDrone_sprite = Resources.Load<Sprite>("Sprites/Icons/RepairDrone");
        m_turret_sprite      = Resources.Load<Sprite>("Sprites/Icons/Turret");
    }

    public ModuleData CreateDefault(ModuleType type)
    {
        string name = Rarity.GREY.ToString() + type.ToString();
        return new ModuleData(type, Rarity.GREY, name, new LevelData(1, 0, baseXPforLevelUp), 1);
    }

    public ModuleData Dice_Module(int level)
    {
        ModuleType type = RandomType();
        int tier = Factory.Dice_BonusTier(level);
        Rarity rarity = Factory.Dice_Rarity();
        string name = Factory.RarityToString(rarity) + " "+ type.ToString();
        return new ModuleData(type,rarity, name, new LevelData(1, 0, baseXPforLevelUp), tier);
    }

    public ModuleType RandomType()
    {
        int newType = (int)Random.Range(1, (int)ModuleType.TOTAL);
        return (ModuleType)newType;
    }


    public void LevelUp(ModuleData module)
    {
        module.Level = new LevelData(module.Level.Current+1, 0, 100);
        Debug.Log("new level:" + module.Level.Current);
    }

    public Sprite GetSprite(ModuleType type)
    {
        switch (type)
        {
            case ModuleType.SHIELD:
                return m_shield_sprite;
            case ModuleType.REPAIRDRONE:
                return m_repairDrone_sprite;
            case ModuleType.TURRET:
                return m_turret_sprite;
            default:
                Debug.Log("error ModuleType:" + type);
                Debug.LogError("Cant load " + type.ToString() + " sprite");
                return Factory.Instance.SpriteError;
        }
    }
}
