using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModuleType { SHIELD = 0, REPAIRDRONE }
// SQUADRONDATA // has 1-* MEMBERDATAS
[System.Serializable]
public class SquadronData
{
    // SQUAD MEMBERS:

    [SerializeField]
    private int m_maxAllies;

    [SerializeReference] // [SerializeReference] is MonoBeahaviour feature to support serialized field inheritance ( using pattern decorator )
    private PlayerData m_player;
    public PlayerData Player { get => m_player; }

    [SerializeField]
    private MemberData[] m_allMembers;
    public MemberData[] AllMembers { get => m_allMembers; }

    // STORED OBJECTS:
    [SerializeField]
    private ModuleData[] m_allStoredModules;
    public ModuleData[] AllStoredModules { get => m_allStoredModules; }

    [SerializeField]
    private ShipData[] m_allStoredShips;
    public ShipData[] AllStoredShips { get => m_allStoredShips; }

    public SquadronData(string PlayerName)
    {
        m_player = new PlayerData(PlayerName);
        m_maxAllies = 1;
        m_allStoredShips = null;
        m_allMembers = new MemberData[2];
        m_allMembers[0] = m_player;
        m_allMembers[1] = new MemberData("ALLY ONE");
        m_allStoredModules = new ModuleData[0];
    }
}

// MEMBERDATA 
[System.Serializable] // Player data is a MemberData
public class PlayerData : MemberData
{
    // Here we'll stock some more player specific datas
    public PlayerData(string name) : base (name)
    {
        
    }
} 

[System.Serializable] // Has 1 ShipData
public class MemberData
{
    [SerializeField]
    private string m_name;
    public string Name { get { return m_name; } set { m_name = value; } }
    [SerializeField]
    private ShipData m_equippedShip;
    public ShipData Ship { get => m_equippedShip; }
    public MemberData(string name)
    {
        m_name = name;
        m_equippedShip = new ShipData("LIGHT FIGHTER", new LevelData(1, 0, 100));
    }
}

//SHIPDATADATA
[System.Serializable] // has 0-* ModuleDatas // has a LevelData
public class ShipData
{
    [SerializeField]
    private string m_name;
    public string Name { get => m_name; }
    [SerializeField]
    private LevelData m_level;
    public LevelData Level { get => m_level; }

    [SerializeField]
    private ModuleData[] m_allModules;
    public ModuleData[] AllModules { get => m_allModules; }

    public ShipData(string name, LevelData lvlData)
    {
        m_name = name;
        m_level = lvlData;
        m_allModules = new ModuleData[3];
        m_allModules[0] = new ModuleData(ModuleType.SHIELD, Rarity.GREY, "", new LevelData(1, 0, 100));
    }
}

//MODULEDATA
[System.Serializable] // has 1 LevelData
public class ModuleData
{

    [SerializeField]
    private ModuleType m_type;
    public ModuleType Type { get => m_type; }
    [SerializeField]
    private Rarity m_rarity;
    public Rarity Rarity { get => m_rarity; }  
    [SerializeField]
    private string m_name;
    public string Name { get => m_name; }

    [SerializeField]
    private LevelData m_level;
    public LevelData Level { get => m_level; }

    public ModuleData(ModuleType type, Rarity rarity, string name, LevelData levelData)
    {
        m_type = type;
        m_rarity = rarity;
        m_level = levelData;
        m_name = rarity + " " + type + name;
    }
}

//LEVELDATA 
[System.Serializable]
public class LevelData
{
    [SerializeField]
    private int m_current;
    public int Current { get => m_current; }
    [SerializeField]
    private float m_xp_current;
    public float Xp_Current { get => m_xp_current; }
    [SerializeField]
    private float m_xp_toNextLevel;
    public float Xp_ToNextLevel{ get => m_xp_toNextLevel; }

    public LevelData(int current, float currentXp, float nextLvLXp)
    {
        m_current = current;
        m_xp_current = currentXp;
        m_xp_toNextLevel = nextLvLXp;
    }
}
