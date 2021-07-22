using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleStat_Factory 
{
    public ModuleStat_Factory()
    {

    }

    public ModuleStat[] Create_Stats(ModuleData data)
    {
        //Debug.LogWarning("NEW TEST:" + tierBaseValue);
        switch (data.Type)
        {
            case ModuleType.REPAIRDRONE:

                ModuleStat[] repairStats = new ModuleStat[2];
                repairStats[0] = new ModuleStat( ModuleStatType.LIFESPAN," LifeSpan: ", Get_Stat(data, ModuleStatType.LIFESPAN,true), Get_Stat(data, ModuleStatType.LIFESPAN, false));
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
    public float Get_Stat( ModuleData data, ModuleStatType request,  bool getCurrent_ifNotMax)
    {
        float levelMax = LevelMax(data.Rarity);

        //double increment = Math.Log(level + 1); // Logarythmic model found on internet
        float tierBaseValue = Mathf.Log(data.Tier + (int)data.Rarity);

        float maxValue = tierBaseValue * levelMax;
        float currentRelatedToMax = data.Level.Current * maxValue / levelMax;

        switch (data.Type)
        {
            case ModuleType.REPAIRDRONE:
                switch(request)
                {
                    case ModuleStatType.LIFESPAN:
                        float lifeRatio = 1/4;
                        switch (getCurrent_ifNotMax) // If request maxValue
                        {
                            case false: return maxValue * lifeRatio;
                        }
                        float lifeSpan = currentRelatedToMax * lifeRatio;
                        return lifeSpan;

                    case ModuleStatType.EFFICIENCY:
                        float efficiencyRatio = 1/12;
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
                        float damageRatio = 1;
                        switch (getCurrent_ifNotMax) // If request maxValue
                        {
                            case false: return maxValue / damageRatio;
                        }
                        float damage = currentRelatedToMax / damageRatio;
                        return damage;
                }
                break;

        }
        return 0;
        
    }

    public int LevelMax(Rarity data)
    {
        return 3 * (((int)data) + 1);
    }
    public int[] Get_UpgradeCost(ModuleData data)
    {
        int[] componentCost = new int[6];
        int rarity = (int)data.Rarity;
        Debug.Log("rarity cost" + rarity);
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

}
