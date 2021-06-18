
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Factory 
{
    private GameObject _shotPrefab;
    public Turret_Factory()
    {
        _shotPrefab = Resources.Load<GameObject>("Prefabs/Shot");
    }

    public Turret CreateTurret(Rarity rarity)
    {
        Debug.Log("new turret rarity" + rarity);
        switch (rarity)
        {
            case Rarity.WHITE:
                return CreateWhite();
            case Rarity.GREEN:
                return CreateGreen();
            case Rarity.BLUE:
                return CreateBlue();
            case Rarity.PURPLE:
                return CreatePurple();
            case Rarity.ORANGE:
                return CreateOrange();
               
            default:
                return CreateGrey();
        }
    }

    private Turret CreateGrey()
    {
        GameObject shotPrefab = _shotPrefab;
        shotPrefab.GetComponent<SpriteRenderer>().material = Factory.Instance.Material_Factory.GetMaterial(Rarity.GREY);
        return new Turret(GameObject.Find("Player").gameObject.transform, 0.6f, Rarity.GREY);
    }
    private Turret CreateWhite()
    {
        GameObject shotPrefab = _shotPrefab;
        shotPrefab.GetComponent<SpriteRenderer>().material = Factory.Instance.Material_Factory.GetMaterial(Rarity.WHITE);
        return new Turret(GameObject.Find("Player").gameObject.transform, 0.4f, Rarity.WHITE);
    }
    private Turret CreateGreen()
    {
        GameObject shotPrefab = _shotPrefab;
        shotPrefab.GetComponent<SpriteRenderer>().material = Factory.Instance.Material_Factory.GetMaterial(Rarity.GREEN);
        return new Turret(GameObject.Find("Player").gameObject.transform, 0.2f, Rarity.GREEN);
    }
    private Turret CreateBlue()
    {
        GameObject shotPrefab = _shotPrefab;
        shotPrefab.GetComponent<SpriteRenderer>().material = Factory.Instance.Material_Factory.GetMaterial(Rarity.BLUE);
        return new Turret(GameObject.Find("Player").gameObject.transform, 0.1f, Rarity.BLUE);
    }
    private Turret CreatePurple()
    {
        GameObject shotPrefab = _shotPrefab;
        shotPrefab.GetComponent<SpriteRenderer>().material = Factory.Instance.Material_Factory.GetMaterial(Rarity.PURPLE);
        return new Turret(GameObject.Find("Player").gameObject.transform, 0.05f, Rarity.PURPLE);
    }
    private Turret CreateOrange()
    {
        GameObject shotPrefab = _shotPrefab;
        shotPrefab.GetComponent<SpriteRenderer>().material = Factory.Instance.Material_Factory.GetMaterial(Rarity.ORANGE);
        return new Turret(GameObject.Find("Player").gameObject.transform, 0.02f, Rarity.ORANGE);
    }

    public Turret CreateRandom()
    {
        return CreateTurret((Rarity)Random.Range(0, (int)Rarity.Total));
    }
}
