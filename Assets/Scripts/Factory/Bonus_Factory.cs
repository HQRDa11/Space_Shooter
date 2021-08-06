using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Factory 
{


    public Bonus_Factory()
    {

    }

    public GameObject Instantiate_DicedBonus(Vector2 position)
    {
        
        int luck = Random.Range(0, 100);  // Turret 62% / Zone 12% / Shield 10% / Repair 8% / Pilot 5% / Component 3% //
        GameObject newBonus;
        if (luck <= 62)
        {
            newBonus = Instantiate_TurretBonus(position, Factory.Dice_Rarity()).gameObject;
            return newBonus;
        }

        else if (luck <= 74)
        {
            newBonus = Instantiate_ZoneBonus(position).gameObject;
            return newBonus;
        }
        else if (luck <= 84)
        {
            newBonus = Instantiate_ShieldBonus(position).gameObject;
            return newBonus;
        }

        else if (luck <= 92)
        {
            newBonus = Instantiate_RepairBonus(position).gameObject;
            return newBonus;
        }

        else if (luck <= 97)
        {
            newBonus = Instantiate_PilotBonus(position).gameObject;
            return newBonus;
        }

        else
        {
            newBonus = Instantiate_ComponentBonus(position, Factory.Dice_Rarity()).gameObject;
            return newBonus;
        }
    }


    public TurretBonus Instantiate_TurretBonus(Vector2 position, Rarity rarity )
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Bonuses/TurretBonus"));
        if (!bonusLoot.GetComponent<TurretBonus>()) { bonusLoot.AddComponent<TurretBonus>(); }
        bonusLoot.transform.position = position;
        bonusLoot.GetComponent<TurretBonus>().Rarity = rarity;
        bonusLoot.GetComponent<SpriteRenderer>().material = GameObject.FindObjectOfType<Factory>().Material_Factory.GetMaterial(rarity);
        return bonusLoot.GetComponent<TurretBonus>();
    }
    public ComponentBonus Instantiate_ComponentBonus(Vector2 position, Rarity rarity)
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Bonuses/ComponentBonus"));
        if (!bonusLoot.GetComponent<ComponentBonus>()) { bonusLoot.AddComponent<ComponentBonus>(); }
        bonusLoot.transform.position = position;
        bonusLoot.GetComponent<ComponentBonus>().Rarity = rarity;
        bonusLoot.GetComponent<SpriteRenderer>().material = GameObject.FindObjectOfType<Factory>().Material_Factory.GetMaterial(rarity);
        return bonusLoot.GetComponent<ComponentBonus>();
    }
    public PilotBonus Instantiate_PilotBonus(Vector2 position)
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Bonuses/PilotBonus"));
        if (!bonusLoot.GetComponent<PilotBonus>()) { bonusLoot.AddComponent<PilotBonus>(); }
        bonusLoot.transform.position = position;
        return bonusLoot.GetComponent<PilotBonus>();
    }
    public RepairBonus Instantiate_RepairBonus(Vector2 position)
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Bonuses/RepairBonus"));
        if (!bonusLoot.GetComponent<RepairBonus>()) { bonusLoot.AddComponent<RepairBonus>(); }
        bonusLoot.transform.position = position;
        return bonusLoot.GetComponent<RepairBonus>();
    }
    public ShieldBonus Instantiate_ShieldBonus(Vector2 position)
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Bonuses/ShieldBonus"));
        if (bonusLoot.GetComponent<ShieldBonus>() == null) { bonusLoot.AddComponent<ShieldBonus>(); Debug.Log("error here"); }
        bonusLoot.transform.position = position;
        return bonusLoot.GetComponent<ShieldBonus>();
    }
    public ZoneBonus Instantiate_ZoneBonus(Vector2 position)
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Bonuses/ZoneBonus"));
        if (!bonusLoot.GetComponent<ZoneBonus>()) { bonusLoot.AddComponent<ZoneBonus>(); }
        bonusLoot.transform.position = position;
        return bonusLoot.GetComponent<ZoneBonus>();
    }

    public GameObject Instantiate_DicedComponent(Rarity minRarity, Vector3 position)
    {
        Rarity diced = Factory.Dice_Rarity(minRarity);
        return Instantiate_ComponentBonus(position,diced).gameObject;
    }
}
