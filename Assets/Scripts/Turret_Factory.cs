
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Factory 
{
    public Turret_Factory()
    {
        
    }

    public Turret CreateTurret(Rarity rarity)
    {
        //Debug.Log("new turret rarity" + rarity);
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
        return new Turret( 0.6f, Rarity.GREY);
    }
    private Turret CreateWhite()
    {
        return new Turret( 0.4f, Rarity.WHITE);
    }
    private Turret CreateGreen()
    {
        return new Turret( 0.2f, Rarity.GREEN);
    }
    private Turret CreateBlue()
    {
        return new Turret(0.1f, Rarity.BLUE);
    }
    private Turret CreatePurple()
    {
        return new Turret(0.05f, Rarity.PURPLE);
    }
    private Turret CreateOrange()
    {
        return new Turret( 0.02f, Rarity.ORANGE);
    }

    public Turret CreateRandom()
    {
        return CreateTurret((Rarity)Random.Range(0, (int)Rarity.Total));
    }
}
