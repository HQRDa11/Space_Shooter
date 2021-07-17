using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadableDataElement<T>
{
    public T Load();
}

[System.Serializable]
public class SquadronData 
{
    [SerializeField]
    private PlayerData m_player;
    public PlayerData Player { get => m_player; }
    [SerializeField]
    private int m_maxAllies;

    [SerializeField]
    private ShipData[] m_allShips;

    [SerializeField]
    private AllyData[] m_allies;

    [SerializeField]
    private ModuleData[] m_allModules;
    
    public SquadronData()
    {
        m_player = new PlayerData("PLAYER");
        m_maxAllies = 1;
        m_allShips = null;
        m_allies = new AllyData[1];
        m_allies[0] = new AllyData("ALLY ONE");
    }
}
[System.Serializable]
public class PlayerData
{
    [SerializeField]
    private string m_name;
    public string name { get => m_name; }
    [SerializeField]
    private ShipData m_equippedShip;

    public PlayerData(string name)
    {
        m_name = name;
        m_equippedShip = new ShipData("LIGHT FIGHTER", new LevelData(1, 0, 100));
    }
}
[System.Serializable]
public class AllyData
{
    [SerializeField]
    private string m_name;
    [SerializeField]
    private ShipData m_equippedShip;
    public AllyData(string name)
    {
        m_name = name;
        m_equippedShip = new ShipData("LIGHT FIGHTER", new LevelData(1, 0, 100));
    }
}
[System.Serializable]
public class ShipData
{
    [SerializeField]
    private string m_name;
    [SerializeField]
    private LevelData m_Level;
    [SerializeField]
    private ModuleData[] m_equippedModules;

    public ShipData(string name,LevelData lvlData)
    {
        m_name = name;
        m_Level = new LevelData(1, 0, 100);
        m_equippedModules = new ModuleData[3];
        m_equippedModules[0] = new ModuleData(ModuleType.SHIELD, Rarity.GREY, "", new LevelData(1, 0, 100));
    }
}

public enum ModuleType { SHIELD = 0, REPAIRDRONE }
[System.Serializable]
public class ModuleData
{
    [SerializeField]
    private ModuleType m_type;
    [SerializeField]
    private Rarity m_rarity;
    [SerializeField]
    private string m_name;
    [SerializeField]
    private LevelData m_Level;

    public ModuleData(ModuleType type, Rarity rarity, string name, LevelData levelData)
    {
        m_type = type;
        m_rarity = rarity;
        m_Level = levelData;
        m_name = rarity + " " + type + name;
    }
}
[System.Serializable]
public class LevelData
{
    [SerializeField]
    private int m_current;
    [SerializeField]
    private float m_xp_current;
    [SerializeField]
    private float m_xp_toNextLevel;

    public LevelData(int current, float currentXp, float nextLvLXp)
    {
        m_current = current;
        m_xp_current = current;
        m_xp_toNextLevel = nextLvLXp;
    }
}
