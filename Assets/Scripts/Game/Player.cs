 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Ship m_ship;
    public Ship Ship { get => m_ship; }
    
    // Ally system
    private Ally[] m_allAllies;
    public Ally[] AllAllies { get => m_allAllies; }


    private GameInfo m_gameInfo;

    // Start is called before the first frame update
    void Start()
    {
        m_allAllies = new Ally[4];

        m_ship = GetComponentInChildren<Ship>();
        m_ship.InitialisePlayerShip(200);

        m_gameInfo = GameObject.Find("GameInfo").GetComponent<GameInfo>();
        if (m_gameInfo == null) Debug.LogError("no GameInfo go found");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) == true)
        {
            OnPilotBonus();
        }
        if (Input.GetKeyDown(KeyCode.U) == true)
        {
            OnRepairDroneBonus();
        }
        if (Input.GetKeyDown(KeyCode.Equals) == true)
        {

            OnComponentBonus(Factory.Dice_Rarity());
        }
    }

    public void Shoot()
    {
        m_ship.GetComponent<TurretSystem>().Shoot();

        for (int i = 0; i<m_allAllies.Length; i++)
        {
            switch (m_allAllies[i]!= null)
            {
                case true:
                    m_allAllies[i].Ship.GetComponent<TurretSystem>().Shoot();
                    break;
            }
        }
    }
    public Vector2 GetRelativeAllyPosition(int id)
    {
        float pos = 0.4f;
        switch (id)
        {
            case 0:
                return (Vector2)this.gameObject.transform.position + new Vector2(pos, -pos / 2);
            case 1:
                return (Vector2)this.gameObject.transform.position + new Vector2(-pos, -pos / 2);
            case 2:
                return (Vector2)this.gameObject.transform.position + new Vector2(pos * 1.8f, -pos);
            case 3:
                return (Vector2)this.gameObject.transform.position + new Vector2(-pos * 1.8f, -pos);
            default:
                Debug.LogError("Undefined possibility");
                return Vector2.zero;
        }
    }

    public void OnTurretBonus(Rarity rarity)
    {
        //this.gameObject.GetComponent<TurretSystem>().AddTurret(Factory.Instance.Turret_Factory.CreateTurret(rarity));
        GameObject.Find("Sound").GetComponent<Sound>().Play_WeaponDeployShort();
        Turret turret = Factory.Instance.Turret_Factory.CreateTurret(rarity);

        switch (m_ship.gameObject.GetComponent<TurretSystem>().AddTurret(turret))
        {
            case true:
                return;
            case false:

                for (int i = 0; i < m_allAllies.Length; i++)
                {
                    switch (m_allAllies[i] != null && m_allAllies[i].Ship.GetComponent<TurretSystem>().AddTurret(turret))
                    {
                        case true:
                            return;
                    }
                }
                //Debug.Log("No room for new Turret");
                return;
        }
    }

    public void OnPilotBonus()
    {
        for (int i=0; i<m_allAllies.Length; i++)
        {
            if (m_allAllies[i] == null)
            {
                Ship newShip = Factory.Instance.Ship_Factory.CreateAllyShip(this.gameObject, GetRelativeAllyPosition(i), i, 200);
                Ally newAlly = new Ally(newShip);
                m_allAllies[i]=newAlly;
                newShip.gameObject.transform.position += Vector3.down * Screen.height / 3;
                return;
            }
        }
    }

    public void OnRepairDroneBonus()
    { 
        switch (this.Ship.RepairDrone == null)
        {
            case true:
                this.Ship.NewRepairDrone();
                return;

            case false:
                RepairDrone lowestDrone = this.Ship.RepairDrone;
                foreach (Ally ally in m_allAllies)
                {
                    switch (ally != null)
                    {
                        case true:
                            switch (ally.Ship != null)
                            {
                                case true:
                                    switch (ally.Ship.RepairDrone == null)
                                    {
                                        case true:
                                            ally.Ship.NewRepairDrone();
                                            return;

                                        case false:
                                            switch (ally.Ship.RepairDrone.LifeSpan < lowestDrone.LifeSpan)
                                            {
                                                case true:
                                                    lowestDrone = ally.Ship.RepairDrone;
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                }
                Debug.LogWarning("Drone Recharge not implemented yet:"); // lowestRepairDrone.RechargeFull();
                return;
        }
    }

    public void OnComponentBonus(Rarity rarity)
    {
        Sound.Instance.Play_ComponentCollect();
        m_gameInfo.AddNewComponent(rarity);
        m_gameInfo.DisplayComponents();
    }

    public Ship Assign_Drone()
    {
        switch(this.Ship.HasDrone == false)
        {
            case true:
                this.Ship.HasDrone = true;
                return this.Ship;

            case false:
                foreach (Ally ally in m_allAllies)
                {
                    switch (ally != null && ally.Ship != null)
                    {
                        case true:
                            switch (ally.Ship.HasDrone)
                            {
                                case false:
                                    ally.Ship.HasDrone = true;
                                    return ally.Ship;
                                default:
                                    break;
                            }
                            break;
                    }
                }
                break;
        }
        return null;
    }

    public void OnShieldBonus() // <= Why is this Method Called 2 times on "ShieldBonus" pick-up? Multiple player collision?
    {
        Debug.LogError("This Should not be printed 2 times on Shield loot"); 
        switch (this.Ship.Shield == null)
        {
            case true:
                this.Ship.NewShield();
                return;

            case false:
                Shield lowestShield = this.Ship.Shield;
                foreach (Ally ally in m_allAllies)
                {
                    switch(ally != null)
                    {
                        case true:
                            switch(ally.Ship != null )
                            {
                                case true:
                                    switch (ally.Ship.Shield == null)
                                    {
                                        case true:
                                            ally.Ship.NewShield();
                                            return;
                                       
                                        case false:
                                            switch (ally.Ship.Shield.Energy < lowestShield.Energy)
                                            {
                                                case true:
                                                    lowestShield = ally.Ship.Shield;
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }

                }
                lowestShield.RechargeFull();
                return;
        }
    }
}
