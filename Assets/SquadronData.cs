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
        m_equippedShip = null;
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
        m_equippedShip = null;
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
}

public enum ModuleType { SHIELD = 0, REPAIRDRONE }
[System.Serializable]
public class ModuleData
{
    [SerializeField]
    private ModuleType m_type;
    [SerializeField]
    private string m_name;
    [SerializeField]
    private LevelData m_Level;
}
[System.Serializable]
public class LevelData
{
    [SerializeField]
    private int m_current;
    [SerializeField]
    private float m_xp_curret;
    [SerializeField]
    private float m_xp_toNextLevel;
}
