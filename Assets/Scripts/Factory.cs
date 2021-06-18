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

    private Shot_Factory _shotFactory;
    public Shot_Factory  Shot_Factory { get => _shotFactory; }

    private void Awake()
    {
        _instance = this;
        _materialFactory = new Material_Factory();
        _bonusFactory = new Bonus_Factory();
        _turretFactory = new Turret_Factory();
        _shotFactory = new Shot_Factory();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

}
