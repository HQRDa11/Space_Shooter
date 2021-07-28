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
    public GameObject CreateShot(Transform parent, Rarity rarity, double damage, Vector2 direction, float speed, string tag)
    {
        //Debug.LogWarning("damage: " + (double)damage + "*" + ((int)rarity) + "= " + (double)damage * ((int)rarity));
        GameObject newShot = GameObject.Instantiate(_shotPrefab, Factory.Instance.InGameObjectsList);
        newShot.GetComponent<SpriteRenderer>().material = Factory.Instance.Material_Factory.GetMaterial(rarity);
        newShot.GetComponent<Shot>().Initialise( (double)damage*((int)rarity), direction, speed );
        newShot.tag = tag;
        return newShot;
    }

    public GameObject Create_DefaultEnemyShot(Vector2 direction)
    {
        return CreateShot(Factory.Instance.InGameObjectsList, Rarity.WHITE, 1, direction, 3f, "Enemy");
    }
}
