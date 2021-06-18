using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Factory : MonoBehaviour
{
    private GameObject _shotPrefab;
    public Shot_Factory()
    {
        _shotPrefab = Resources.Load<GameObject>("Prefabs/Shot");
    }
    public GameObject CreateShot(Rarity rarity)
    {
        GameObject newShot = GameObject.Instantiate(_shotPrefab);
        newShot.GetComponent<SpriteRenderer>().material = Factory.Instance.Material_Factory.GetMaterial(rarity);
        newShot.GetComponent<Shot>().Initialise(1 / ((int)rarity +1 ));
        return newShot;
    }
}
