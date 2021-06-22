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
        GameObject newShip = GameObject.Instantiate(_shipPrefab, parent.transform);
        newShip.transform.position = relativePosition;
        if (!newShip.GetComponent<Ship>())
        {
            newShip.AddComponent<Ship>();
        }
        newShip.transform.localScale *= 0.8f;
        newShip.GetComponent<Ship>().Initialise(id, maxHealth);
        return newShip.GetComponent<Ship>();
    }
                
}
