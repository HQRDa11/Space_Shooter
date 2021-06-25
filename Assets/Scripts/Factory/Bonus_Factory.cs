using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Factory 
{


    public Bonus_Factory()
    {

    }

    public void Instantiate_RandomBonus(Vector2 position)
    {
        int luck = Random.Range(0, 100);

        if ( luck <= 23 )
        {
            Instantiate_TurretBonus(position, Rarity.GREY);
                return;
        }
        else if ( luck <= 40 )
        {
            Instantiate_TurretBonus(position, Rarity.WHITE);
            return;
        }
        else if ( luck <= 52 )
        {
            Instantiate_TurretBonus(position, Rarity.GREEN);
            return;
        }
        else if ( luck <= 60 )
        {
            Instantiate_TurretBonus(position, Rarity.BLUE);
            return;
        }        
        else if ( luck <= 65 )
        {
            Instantiate_TurretBonus(position, Rarity.PURPLE);
            return;
        }
        else if (luck <= 67)
        {
            Instantiate_TurretBonus(position, Rarity.ORANGE);
            return;
        }  
        else if (luck <= 80)
        {
            Instantiate_ZoneBonus(position);
            return;
        }

        else if (luck <= 90)
        {
            Instantiate_RepairBonus(position);
            return;
        }

        else 
        {
            Instantiate_PilotBonus(position);
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
