using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Factory 
{
    private GameObject _bonusPrefab;

    public Bonus_Factory()
    {
        _bonusPrefab = Resources.Load<GameObject>("Prefabs/Bonus");
    }
    public Bonus InstantiateBonus(Vector2 position)
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Bonus"));
        if (!bonusLoot.GetComponent<Bonus>()) { bonusLoot.AddComponent<Bonus>(); }
        bonusLoot.transform.position = position;
        Rarity rarity = (Rarity)Random.Range(0, (int)Rarity.Total);
        bonusLoot.GetComponent<Bonus>().Rarity = rarity;
        bonusLoot.GetComponent<SpriteRenderer>().material = GameObject.FindObjectOfType<Factory>().Material_Factory.GetMaterial(rarity);
        return bonusLoot.GetComponent<Bonus>();
    }

}
