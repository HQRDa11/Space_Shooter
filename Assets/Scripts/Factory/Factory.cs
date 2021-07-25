using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private static Factory _instance;
    public static Factory Instance { get => _instance; }

    private Material_Factory _materialFactory;
    public Material_Factory Material_Factory { get => _materialFactory; }

    private Bonus_Factory _bonusFactory;
    public Bonus_Factory Bonus_Factory { get => _bonusFactory; }

    private Turret_Factory _turretFactory;
    public Turret_Factory Turret_Factory { get => _turretFactory; }

    private Module_Factory _moduleFactory;
    public Module_Factory Module_Factory { get => _moduleFactory; }

    private ModuleStat_Factory _moduleStat_Factory;
    public ModuleStat_Factory ModuleStat_Factory { get => _moduleStat_Factory; }

    private Shot_Factory _shotFactory;
    public Shot_Factory  Shot_Factory { get => _shotFactory; }

    private Ship_Factory _shipFactory;
    public Ship_Factory Ship_Factory { get => _shipFactory; }

    private Enemy_Factory _enemyFactory;
    public Enemy_Factory Enemy_Factory { get => _enemyFactory; }

    public static Transform _InGameObjects_Parent;

    public General_Factory _generalFactory;
    public General_Factory General_Factory { get => _generalFactory; }

    public Sprite SpriteError { get => Resources.Load<Sprite>("Sprites/Icons/SpriteError"); } 

    private void Awake()
    {
        _instance = this;
        _materialFactory = new Material_Factory();
        _moduleFactory = new Module_Factory();
        _moduleStat_Factory = new ModuleStat_Factory();
        _bonusFactory = new Bonus_Factory();
        _turretFactory = new Turret_Factory();
        _shotFactory = new Shot_Factory();
        _shipFactory = new Ship_Factory();
        _enemyFactory = new Enemy_Factory();
        _generalFactory = new General_Factory();
    }

    public Transform InGameObjectsList { get => _InGameObjects_Parent; }
    public void SetInGameObjects_Parent(Transform parent)
    {
        _InGameObjects_Parent = parent;
    }
    // Start is called before the first frame update
    void Update()
    {
        switch (Input.GetKeyDown(KeyCode.B))
        {
            case true:
                _bonusFactory.Instantiate_DicedBonus(Vector3.zero);
                break;
        }
    }
    public static int Dice_BonusTier(int tier)
    {
        int luck = Random.Range(0, 100);
        return (luck <= 60) ? tier : (luck <= 90 ) ? tier + 1 : tier + 2;
    }

    public static string RarityToString(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.GREY:
                return "COMMON";
            case Rarity.WHITE:
                return "UNCOMMON";
            case Rarity.GREEN:
                return "RARE";
            case Rarity.BLUE:
                return "EXEPTIONNAL";
            case Rarity.PURPLE:
                return "UNIQUE";
            case Rarity.ORANGE:
                return "LEGENDARY";
            default:
                return "RarityError";
        }
    }
    public static Rarity Dice_Rarity() // Dice according to a rarity ratio standard // Tweak it wisely 
                                       // Current uses : Turret Bonus, Modules/Components loot 
    {
        int luck = Random.Range(0, 100); // GREY 53% / WHITE 25% / GREEN 12% / BLUE 6% / PURPLE 3% / ORANGE 1% //

        if (luck <= 53)
        {
            return Rarity.GREY;
        }
        else if (luck <= 78)
        {
            return Rarity.WHITE;
        }
        else if (luck <= 90)
        {
            return Rarity.GREEN;
        }
        else if (luck <= 96)
        {
            return Rarity.BLUE;
        }
        else if (luck <= 99)
        {
            return Rarity.PURPLE;
        }
        else
        {
            return Rarity.ORANGE;
        }
    }

}
