using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Factory 
{
    private GameObject _shipPrefab;

    public Ship_Factory()
    {
        _shipPrefab = Resources.Load<GameObject>("Prefabs/Ship1");
    }

    public Ship CreateAllyShip(GameObject parent, Vector2 relativePosition,int id, float maxHealth)
    {
        GameObject newShip = GameObject.Instantiate(_shipPrefab);
        newShip.transform.position = relativePosition;
        if (!newShip.GetComponent<Ship>())
        {
            newShip.AddComponent<Ship>();
        }
        newShip.transform.localScale *= 0.8f;
        newShip.GetComponent<Ship>().InitialiseAllyShip(id, maxHealth);

        switch ( id == 0 || id == 1)
        {
            case true:
                newShip.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "AllyShipLvl1";
                break;
            case false:
                newShip.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "AllyShipLvl2";
                break;
        }

        TurretSlot[] allturrets = newShip.GetComponentsInChildren<TurretSlot>();
        foreach (TurretSlot slot in allturrets)
        {
            slot.Damage = 1+newShip.GetComponent<Ship>().TurretDamageBonus;
        }

        return newShip.GetComponent<Ship>();
    }


    // LEVELING
    public int LevelMax(Rarity data)
    {
        return 3 * (((int)data) + 1);
    }
    public void LevelUp(ShipData data)
    {
        data.Level = new LevelData(data.Level.Current + 1, 0, 100);
        Debug.Log("new level:" + data.Level.Current);
    }

    // STATS
    public ShipStat[] Create_Stats(ShipData data)
    {
            ShipStat[] newStats = new ShipStat[2];
            newStats[0] = new ShipStat(ShipStatType.HULL, " Hull: ", Get_Stat(data, ShipStatType.HULL, true), Get_Stat(data, ShipStatType.HULL, false));
            newStats[1] = new ShipStat(ShipStatType.MAX_MODULES, " Max Modules: ", Get_Stat(data, ShipStatType.MAX_MODULES, true), Get_Stat(data, ShipStatType.MAX_MODULES, false));
            //newStats[2] = new ShipStat(ShipStatType.MAX_TURRETS, " Max Turrets: ", Get_Stat(data, ShipStatType.MAX_TURRETS, true), Get_Stat(data, ShipStatType.MAX_TURRETS, false));
        
            return newStats;
    }

    public float Get_Stat(ShipData data, ShipStatType request, bool getCurrent_ifNotMax)
    {
        float levelMax = LevelMax(data.Rarity);

        //double increment = Math.Log(level + 1); // Logarythmic model found on internet
        float tierBaseValue = Mathf.Log(data.Tier + (int)data.Rarity);

        float maxValue = tierBaseValue * levelMax;
        float currentRelatedToMax = data.Level.Current * maxValue / levelMax;

            switch (request)
            {
                case ShipStatType.HULL:
                    float hullRatio = 30;
                    switch (getCurrent_ifNotMax) // If request maxValue
                    {
                        case false: return maxValue * hullRatio;
                    }
                    float hull = currentRelatedToMax * hullRatio;
                    return hull;

                case ShipStatType.MAX_MODULES:
                    float maxModulesRatio = 1 / 4f;
                    switch (getCurrent_ifNotMax) // If request maxValue
                    {
                        case false: return Mathf.RoundToInt(maxValue * maxModulesRatio);
                    }
                    int maxModules = Mathf.RoundToInt(currentRelatedToMax * maxModulesRatio);
                    return maxModules;

                case ShipStatType.MAX_TURRETS:
                    float maxTurretRatio = 1 / 2f;
                    switch (getCurrent_ifNotMax) // If request maxValue
                    {
                        case false: return Mathf.RoundToInt(maxValue * maxTurretRatio);
                    }
                    int maxTurrets = Mathf.RoundToInt(currentRelatedToMax * maxTurretRatio);
                    return maxTurrets;
            }
        return 0;
    }
    public int[] Get_UpgradeCost(ShipData data)
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
    public enum ShipStatType { Null, HULL = 0, MAX_MODULES, MAX_TURRETS}
    public struct ShipStat
    {
        //public ModuleType type;
        public ShipStatType Type;
        public string Name;
        public float Value;
        public float MaxValue;

        public ShipStat(ShipStatType type, string name, float value, float maxValue)
        {
            Type = type;
            Name = name;
            Value = value;
            MaxValue = maxValue;
        }
    }
}

