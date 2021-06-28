using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Factory 
{
    private GameObject _shotPrefab;
    public Shot_Factory()
    {
        _shotPrefab = Resources.Load<GameObject>("Prefabs/Shot");
    }
    public GameObject CreateShot(Transform parent, Rarity rarity, Vector2 direction, float speed, string tag)
    {
        GameObject newShot = GameObject.Instantiate(_shotPrefab, Factory.Instance.InGameObjectsList);
        newShot.GetComponent<SpriteRenderer>().material = Factory.Instance.Material_Factory.GetMaterial(rarity);
        newShot.GetComponent<Shot>().Initialise( (int)rarity, direction, speed );
        newShot.tag = tag;
        return newShot;
    }
}
