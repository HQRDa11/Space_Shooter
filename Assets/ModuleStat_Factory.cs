using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleStat_Factory 
{
    public ModuleStat_Factory()
    {

    }

    public int[] Get_UpgradeCost(ModuleData data)
    {
        int[] componentCost = new int[6];
        int rarity = (int)data.Rarity;
        Debug.Log("rarity cost" + rarity);
        int tier = data.Tier;
        
        for (int h = rarity; h!=0; h--)
        {
            for (int index = 0; index<rarity; index++)
            {
                componentCost[index] += tier;
            }
            rarity--;
        }

        Debug.Log("cost:" + componentCost.ToString());
        return componentCost;
    }

    public ModuleStat[] Create_Stats(ModuleData data)
    {
        int levelMax = LevelMax(data.Rarity);
        //double increment = Math.Log(level + 1);

        float tierBaseValue = Mathf.Log(data.Tier+(int)data.Rarity);
        float maxValue = tierBaseValue * levelMax;

        float currentValue = data.Level.Current * maxValue / levelMax;


        //Debug.LogWarning("NEW TEST:" + tierBaseValue);
        switch (data.Type)
        {
            case ModuleType.REPAIRDRONE:

                ModuleStat[] repairStats = new ModuleStat[2];

                float lifeRatio = 4;
                float lifeSpan = currentValue / lifeRatio;
                repairStats[0] = new ModuleStat( " LifeSpan: ", lifeSpan,maxValue/lifeRatio);

                float efficiencyRatio = 12;
                float efficiency = currentValue / efficiencyRatio;
                repairStats[1] = new ModuleStat(" Efficiency: ", efficiency, maxValue / efficiencyRatio);

                return repairStats;

            case ModuleType.SHIELD:

                ModuleStat[] shieldStat = new ModuleStat[1];

                float energyRatio = 2;
                float energy = currentValue / energyRatio;
                shieldStat[0] = new ModuleStat(" Energy: ", energy, maxValue / energyRatio);

                return shieldStat;

            case ModuleType.TURRET:

                ModuleStat[] turretStat = new ModuleStat[1];

                float damageRatio = 2;
                float damage = currentValue / damageRatio;
                turretStat[0] = new ModuleStat(" Energy: ", damage, maxValue / damageRatio);

                return turretStat;
        }
        return null;
    }

    public int LevelMax(Rarity data)
    {
        return 3 * (((int)data) + 1);
    }
}
