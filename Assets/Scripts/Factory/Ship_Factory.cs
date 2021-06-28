using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Factory 
{
    private GameObject _shipPrefab;


    public Ship_Factory()
    {
        _shipPrefab = Resources.Load<GameObject>("Prefabs/Ship1");
    }

    public Ship CreateAllyShip(GameObject parent, Vector2 relativePosition,int id, float maxHealth)
    {
        GameObject newShip = GameObject.Instantiate(_shipPrefab);
        newShip.transform.position = relativePosition;
        if (!newShip.GetComponent<Ship>())
        {
            newShip.AddComponent<Ship>();
        }
        newShip.transform.localScale *= 0.8f;
        newShip.GetComponent<Ship>().InitialiseAllyShip(id, maxHealth);

        switch ( id == 0 || id == 1)
        {
            case true:
                newShip.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "AllyShipLvl1";
                break;
            case false:
                newShip.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "AllyShipLvl2";
                break;
        }

        return newShip.GetComponent<Ship>();
    }
                
}
