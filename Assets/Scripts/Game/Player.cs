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
    //private int m_maxAllies;

    // Start is called before the first frame update
    void Start()
    {
        m_allAllies = new Ally[4];
        //m_maxAllies = 4;

        m_ship = GetComponentInChildren<Ship>();
        m_ship.InitialisePlayerShip(200);
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
        GameObject.Find("Sound").GetComponent<Sound>().Play_WeaponDeploy();
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
                Debug.Log("No room for new Turret");
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
                return;
            }
        }
    }

    public void OnRepairBonus()
    {
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/RepairDrone"));
    }

}
