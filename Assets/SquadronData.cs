using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModuleType { NULL = 0, SHIELD, REPAIRDRONE, TURRET, TOTAL }
// SQUADRONDATA // has 1-* MEMBERDATAS
[System.Serializable]
public class SquadronData
{
    // SQUAD MEMBERS:

    //[SerializeField]
    //private int m_maxAllies;

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
        // m_maxAllies = 2;
        m_allStoredShips = null;
        m_allMembers = new MemberData[3];
        m_allMembers[0] = m_player;
        m_allMembers[1] = new MemberData("ALLY ONE");
        m_allMembers[2] = new MemberData("ALLY TWO");
        m_allStoredModules = new ModuleData[1];
    }

    public void Add_StoredModule(ModuleData newModule)
    {
        ModuleData[] newList = new ModuleData[m_allStoredModules.Length + 1];
        for (int i=0;i<m_allStoredModules.Length;i++)
        {
            newList[i] = m_allStoredModules[i];
        }
        newList[m_allStoredModules.Length] = newModule;
        m_allStoredModules = newList;
    }
    public void Remove_StoredModule(int atIndex)
    {
        ModuleData[] newList = new ModuleData[m_allStoredModules.Length-1];
        for (int i = 0; i < newList.Length; i++)
        {
            switch (i < atIndex)
            {
                case true:
                    newList[i] = m_allStoredModules[i];
                    break;
                case false:
                    newList[i] = m_allStoredModules[i+1];
                    break;
            }
        }
        m_allStoredModules = newList;
    }
}

// MEMBERDATA 
[System.Serializable] // Player data is a MemberData
public class PlayerData : MemberData
{
    // Here we'll stock some more player specific datas
    public PlayerData(string name) : base (name)
    {
        m_name = "[noID]";
        m_equippedShip = new ShipData("FREGATE", new LevelData(3, 0, 100));
        m_equippedShip.AllModules[0] = Factory.Instance.Module_Factory.Dice_Module(3);
        m_equippedShip.AllModules[1] = Factory.Instance.Module_Factory.Dice_Module(2);
    }
} 

[System.Serializable] // Has 1 ShipData
public class MemberData
{
    [SerializeField]
    protected string m_name;
    public string Name { get { return m_name; } set { m_name = value; } }
    [SerializeField]
    protected ShipData m_equippedShip;
    public ShipData Ship { get => m_equippedShip; }
    public MemberData(string name)
    {
        m_name = name;
        m_equippedShip = new ShipData("LIGHT FIGHTER", new LevelData(Random.Range(1,5), 0, 100));
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
    private int m_tier;
    public int Tier { get => m_tier; }

    [SerializeReference]
    private Rarity m_rarity;
    public Rarity Rarity { get => m_rarity; }

    [SerializeField]
    private LevelData m_level;
    public LevelData Level { get => m_level; set { m_level = value; } }

    [SerializeField]
    private ModuleData[] m_allModules;
    public ModuleData[] AllModules { get => m_allModules; }

    public ShipData(string name, LevelData lvlData)
    {
        m_name = name;
        m_level = lvlData;
        m_rarity = Rarity.WHITE;
        m_tier = 1;
        m_allModules = new ModuleData[2];
        AllModules[0] = Factory.Instance.Module_Factory.Dice_Module(2);
        AllModules[1] = Factory.Instance.Module_Factory.Dice_Module(1);
    }
    public bool EquipModule(int sourceIndex, int atIndex)
    {
        if (m_allModules[atIndex]!= null)
        {
            ModuleData incoming = ProfileHandler.Instance.ActiveProfile.SquadronData.AllStoredModules[sourceIndex];
            if (incoming != null && incoming.Type != ModuleType.NULL)
            {
                ProfileHandler.Instance.ActiveProfile.SquadronData.Add_StoredModule(m_allModules[atIndex]);
                m_allModules[atIndex] = incoming;
                ProfileHandler.Instance.ActiveProfile.SquadronData.Remove_StoredModule(sourceIndex);
                return true;
            }
        }
        return false;
    }
}

//MODULEDATA
[System.Serializable] // has 1 LevelData
public class ModuleData
{
    public string FullName { get => "T" + Tier.ToString() + " " + m_name + " LVL " + m_level.Current.ToString(); }
    [SerializeField]
    private ModuleType m_type;
    public ModuleType Type { get => m_type; }

    [SerializeReference]
    private Rarity m_rarity;
    public Rarity Rarity { get => m_rarity; }
    [SerializeField]
    private string m_name;
    public string Name { get => m_name; }
    [SerializeField]
    private int m_tier;
    public int Tier { get => m_tier; }

    [SerializeField]
    private LevelData m_level;
    public LevelData Level { get => m_level; set { m_level = value; } }

    public ModuleData()
    {
        m_type = ModuleType.SHIELD;
        m_rarity = Rarity.ORANGE;
        m_name = "ErrorObject";
        m_level = new LevelData (0,10,100);
        m_tier = 0;
        //m_sprite = Factory.Instance.ModuleFactory
    }

    public ModuleData(ModuleType type, Rarity rarity, string name, LevelData levelData, int tier)
    {
        m_type = type;
        m_rarity = rarity;
        m_name = name;
        m_level = levelData;
        m_tier = tier;
        //m_sprite = Factory.Instance.ModuleFactory
    }
    public Sprite Sprite()
    {
        return Factory.Instance.Module_Factory.GetSprite(m_type);
    }
}

//LEVELDATA 
[System.Serializable]
public class LevelData
{
    [SerializeField]
    private int m_current;
    public int Current { get => m_current; set { m_current = value; } }
    [SerializeField]
    private float m_xp_current;
    public float Xp_Current { get => m_xp_current; }
    [SerializeField]
    private float m_xp_toNextLevel;
    public float Xp_ToNextLevel { get => m_xp_toNextLevel; }

    public LevelData(int current, float currentXp, float nextLvLXp)
    {
        m_current = current;
        m_xp_current = currentXp;
        m_xp_toNextLevel = nextLvLXp;
    }
}