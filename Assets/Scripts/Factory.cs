using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private Material_Factory _materialFactory;
    public Material_Factory Material_Factory { get => _materialFactory; }


    private Bonus_Factory _bonusFactory;
    public Bonus_Factory Bonus_Factory { get => _bonusFactory; }

    // Start is called before the first frame update
    void Start()
    {
        _materialFactory = new Material_Factory();
        _bonusFactory = new Bonus_Factory();
    }

}
