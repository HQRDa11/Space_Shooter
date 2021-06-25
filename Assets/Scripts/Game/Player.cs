using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Ship m_ship;
    public Ship Ship { get => m_ship; }
    
    // Ally system
    private List<Ally> m_allAllies;
    public List<Ally> AllAllies { get => m_allAllies; }
    private int m_maxAllies;

    // Start is called before the first frame update
    void Start()
    {
        m_allAllies = new List<Ally>();
        m_maxAllies = 4;

        m_ship = GetComponentInChildren<Ship>();
        m_ship.Initialise(0, 200);
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
            OnRepairBonus();
        }
    }

    public void Shoot()
    {
        m_ship.GetComponent<TurretSystem>().Shoot();

        foreach(Ally ally in m_allAllies)
        {
            ally.Ship.GetComponent<TurretSystem>().Shoot();
        }
    }

    public void OnTurretBonus(Rarity rarity)
    {
        //this.gameObject.GetComponent<TurretSystem>().AddTurret(Factory.Instance.Turret_Factory.CreateTurret(rarity));
        GameObject.Find("Sound").GetComponent<Sound>().Play_WeaponDeploy();
        Turret turret = Factory.Instance.Turret_Factory.CreateTurret(rarity);

        switch (m_ship.gameObject.GetComponent<TurretSystem>().AddTurret(turret))
        {
            case true:
                return;
            case false:
                foreach(Ally ally in m_allAllies)
                {
                    switch (ally.Ship.GetComponent<TurretSystem>().AddTurret(turret))
                    {
                        case true:
                            return;
                    }
                }
                Debug.Log("No room for new Turret");
                return;
        }
    }
    public void OnPilotBonus()
    {
        if (m_allAllies.Count < m_maxAllies)
        {
            Ship newShip = Factory.Instance.Ship_Factory.CreateAllyShip(this.gameObject, GetRelativeAllyPosition(),m_allAllies.Count+1,200);
            Ally newAlly = new Ally(newShip);
            m_allAllies.Add(newAlly);
        }
    }

    private Vector2 GetRelativeAllyPosition()
    {
        float pos = 0.4f;
        switch ( m_allAllies.Count + 1)
        {
            case 1:
                return (Vector2)this.gameObject.transform.position + new Vector2( pos,   -pos/2);
            case 2:
                return (Vector2)this.gameObject.transform.position + new Vector2(-pos,   -pos/2);
            case 3:
                return (Vector2)this.gameObject.transform.position + new Vector2( pos*1.8f, -pos);
            case 4:
                return (Vector2)this.gameObject.transform.position + new Vector2(-pos*1.8f, -pos);
            default:
                Debug.LogError("Undefined possibility");
                return Vector2.zero;
        }
    }

    public void OnRepairBonus()
    {
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/RepairDrone"));
    }
}
