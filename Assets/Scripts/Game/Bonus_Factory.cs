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

        if ( luck <= 35 )
        {
            Instantiate_TurretBonus(position, Rarity.GREY);
                return;
        }
        else if ( luck <= 60 )
        {
            Instantiate_TurretBonus(position, Rarity.WHITE);
            return;
        }
        else if ( luck <= 75 )
        {
            Instantiate_TurretBonus(position, Rarity.GREEN);
            return;
        }
        else if ( luck <= 83 )
        {
            Instantiate_TurretBonus(position, Rarity.BLUE);
            return;
        }        
        else if ( luck <= 87 )
        {
            Instantiate_TurretBonus(position, Rarity.PURPLE);
            return;
        }
        else if (luck <= 89)
        {
            Instantiate_TurretBonus(position, Rarity.ORANGE);
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
}
