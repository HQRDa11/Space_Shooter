using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Factory
{
    private int baseXPforLevelUp = 100; // Should be put in LevelData class CSTR

    private Sprite m_shield_sprite;
    private Sprite m_repairDrone_sprite;
    private Sprite m_turret_sprite;
    private Sprite m_nullModule_sprite;

    public Module_Factory()
    {
        m_shield_sprite      = Resources.Load<Sprite>("Sprites/Icons/Shield");
        m_repairDrone_sprite = Resources.Load<Sprite>("Sprites/Icons/RepairDrone");
        m_turret_sprite      = Resources.Load<Sprite>("Sprites/Icons/Turret");
        m_nullModule_sprite = Resources.Load<Sprite>("Sprites/Icons/NullModule");
    }

    // FACTORY
    public ModuleData CreateDefault(ModuleType type)
    {
        string name = Rarity.GREY.ToString() + type.ToString();
        return new ModuleData(type, Rarity.GREY, name, new LevelData(1, 0, baseXPforLevelUp), 1);
    }
    public ModuleData Dice_ModuleData(int level)
    {
        ModuleType type = RandomType();
        int tier = Factory.Dice_BonusTier(level);
        Rarity rarity = Factory.Dice_Rarity();
        string name = Factory.RarityToString(rarity) + " "+ type.ToString();
        return new ModuleData(type,rarity, name, new LevelData(1, 0, baseXPforLevelUp), tier);
    }

    // TYPE
    public ModuleType RandomType()
    {
        int newType = (int)Random.Range(1, (int)ModuleType.TOTAL);
        return (ModuleType)newType;
    }

    // GRAPHIC 
    public Sprite GetSprite(ModuleType type)
    {
        switch (type)
        {
            case ModuleType.NULL:
                return m_nullModule_sprite;
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

    // LEVELING
    public int LevelMax(Rarity data)
    {
        return 3 * (((int)data) + 1);
    }
    public void LevelUp(ModuleData module)
    {
        module.Level = new LevelData(module.Level.Current+1, 0, 100);
        Debug.Log("new level:" + module.Level.Current);
    }

    // STATS
    public ModuleStat[] Create_Stats(ModuleData data)
    {
        //Debug.LogWarning("NEW TEST:" + tierBaseValue);
        switch (data.Type)
        {
            case ModuleType.REPAIRDRONE:

                ModuleStat[] repairStats = new ModuleStat[2];
                repairStats[0] = new ModuleStat(ModuleStatType.LIFESPAN, " LifeSpan: ", Get_Stat(data, ModuleStatType.LIFESPAN, true), Get_Stat(data, ModuleStatType.LIFESPAN, false));
                repairStats[1] = new ModuleStat(ModuleStatType.EFFICIENCY, " Efficiency: ", Get_Stat(data, ModuleStatType.EFFICIENCY, true), Get_Stat(data, ModuleStatType.EFFICIENCY, false));
                return repairStats;

            case ModuleType.SHIELD:

                ModuleStat[] shieldStat = new ModuleStat[1];
                shieldStat[0] = new ModuleStat(ModuleStatType.ENERGY, " Energy: ", Get_Stat(data, ModuleStatType.ENERGY, true), Get_Stat(data, ModuleStatType.ENERGY, false));
                return shieldStat;

            case ModuleType.TURRET:

                ModuleStat[] turretStat = new ModuleStat[1];
                turretStat[0] = new ModuleStat(ModuleStatType.DAMAGE, " Damage: ", Get_Stat(data, ModuleStatType.DAMAGE, true), Get_Stat(data, ModuleStatType.DAMAGE, false));
                return turretStat;
        }
        return null;
    }
    public float Get_Stat(ModuleData data, ModuleStatType request, bool getCurrent_ifNotMax)
    {
        float levelMax = LevelMax(data.Rarity);

        //double increment = Math.Log(level + 1); // Logarythmic model found on internet
        float tierBaseValue = Mathf.Log(data.Tier + (int)data.Rarity);

        float maxValue = tierBaseValue * levelMax;
        float currentRelatedToMax = data.Level.Current * maxValue / levelMax;

        switch (data.Type)
        {
            case ModuleType.REPAIRDRONE:
                switch (request)
                {
                    case ModuleStatType.LIFESPAN:
                        float lifeRatio = 1 / 4f;
                        switch (getCurrent_ifNotMax) // If request maxValue
                        {
                            case false: return maxValue * lifeRatio;
                        }
                        float lifeSpan = currentRelatedToMax * lifeRatio;
                        return lifeSpan;

                    case ModuleStatType.EFFICIENCY:
                        float efficiencyRatio = 1 / 12f;
                        switch (getCurrent_ifNotMax) // If request maxValue
                        {
                            case false: return maxValue * efficiencyRatio;
                        }
                        float efficiency = currentRelatedToMax * efficiencyRatio;
                        return efficiency;
                }
                break;

            case ModuleType.SHIELD:
                switch (request)
                {
                    case ModuleStatType.ENERGY:
                        float energyRatio = 3;
                        switch (getCurrent_ifNotMax) // If request maxValue
                        {
                            case false: return maxValue * energyRatio;
                        }
                        float energy = currentRelatedToMax * energyRatio;
                        return energy;
                }
                break;

            case ModuleType.TURRET:
                switch (request)
                {
                    case ModuleStatType.DAMAGE:
                        float damageRatio = 1 / 5f;
                        switch (getCurrent_ifNotMax) // If request maxValue
                        {
                            case false: return maxValue * damageRatio;
                        }
                        float damage = currentRelatedToMax * damageRatio;
                        return damage;
                }
                break;

        }
        return 0;

    }
    public int[] Get_UpgradeCost(ModuleData data)
    {
        int[] componentCost = new int[6];
        int rarity = (int)data.Rarity;
        int tier = data.Tier;

        for (int h = rarity; h != 0; h--)
        {
            for (int index = 0; index < rarity; index++)
            {
                componentCost[index] += tier;
            }
            rarity--;
        }

        Debug.Log("cost:" + componentCost.ToString());
        return componentCost;
    }

    public enum ModuleStatType { Null, POWER = 0, ENERGY, DAMAGE, LIFESPAN, EFFICIENCY }
    public struct ModuleStat
    {
        //public ModuleType type;
        public ModuleStatType Type;
        public string Name;
        public float Value;
        public float MaxValue;

        public ModuleStat(ModuleStatType type, string name, float value, float maxValue)
        {
            Type = type;
            Name = name;
            Value = value;
            MaxValue = maxValue;
        }
    }
}
