using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Factory 
{


    public Bonus_Factory()
    {

    }

    public void Instantiate_DicedBonus(Vector2 position)
    {
        
        int luck = Random.Range(0, 100);  // Turret 67% / Zone 15% / Repair 10% / Pilot 5% / Component 3% //
       
        if (luck <= 67)
        {
            Instantiate_TurretBonus(position, Factory.Dice_Rarity());
            return;
        }

        else if (luck <= 82)
        {
            Instantiate_ZoneBonus(position);
            return;
        }

        else if (luck <= 92)
        {
            Instantiate_RepairBonus(position);
            return;
        }

        else if (luck <= 97)
        {
            Instantiate_PilotBonus(position);
            return;
        }

        else
        {
            Instantiate_ComponentBonus(position, Factory.Dice_Rarity());
            return;
        }
    }


    public TurretBonus Instantiate_TurretBonus(Vector2 position, Rarity rarity )
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/TurretBonus"));
        if (!bonusLoot.GetComponent<TurretBonus>()) { bonusLoot.AddComponent<TurretBonus>(); }
        bonusLoot.transform.position = position;
        bonusLoot.GetComponent<TurretBonus>().Rarity = rarity;
        bonusLoot.GetComponent<SpriteRenderer>().material = GameObject.FindObjectOfType<Factory>().Material_Factory.GetMaterial(rarity);
        return bonusLoot.GetComponent<TurretBonus>();
    }
    public ComponentBonus Instantiate_ComponentBonus(Vector2 position, Rarity rarity)
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/ComponentBonus"));
        if (!bonusLoot.GetComponent<ComponentBonus>()) { bonusLoot.AddComponent<ComponentBonus>(); }
        bonusLoot.transform.position = position;
        bonusLoot.GetComponent<ComponentBonus>().Rarity = rarity;
        bonusLoot.GetComponent<SpriteRenderer>().material = GameObject.FindObjectOfType<Factory>().Material_Factory.GetMaterial(rarity);
        return bonusLoot.GetComponent<ComponentBonus>();
    }
    public PilotBonus Instantiate_PilotBonus(Vector2 position)
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/PilotBonus"));
        if (!bonusLoot.GetComponent<PilotBonus>()) { bonusLoot.AddComponent<PilotBonus>(); }
        bonusLoot.transform.position = position;
        return bonusLoot.GetComponent<PilotBonus>();
    }
    public RepairBonus Instantiate_RepairBonus(Vector2 position)
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/RepairBonus"));
        if (!bonusLoot.GetComponent<RepairBonus>()) { bonusLoot.AddComponent<RepairBonus>(); }
        bonusLoot.transform.position = position;
        return bonusLoot.GetComponent<RepairBonus>();
    }
    public ZoneBonus Instantiate_ZoneBonus(Vector2 position)
    {
        GameObject bonusLoot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/ZoneBonus"));
        if (!bonusLoot.GetComponent<ZoneBonus>()) { bonusLoot.AddComponent<ZoneBonus>(); }
        bonusLoot.transform.position = position;
        return bonusLoot.GetComponent<ZoneBonus>();
    }
}
