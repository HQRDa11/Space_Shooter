using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Ship m_ship; // not done yet

    // Ally system
    private List<Ally> m_allAllies;
    private int m_maxAllies;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TurretSystem>().Initialise();

        m_allAllies = new List<Ally>();
        m_maxAllies = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) == true)
        {
            OnPilotBonus();
        }
    }

    public void OnTurretBonus(Rarity rarity)
    {
        Debug.Log("bonus on");
        this.gameObject.GetComponent<TurretSystem>().AddTurret(Factory.Instance.Turret_Factory.CreateTurret(rarity));
    }
    public void OnPilotBonus()
    {
        if (m_allAllies.Count < m_maxAllies)
        {
            Ship newShip = Factory.Instance.Ship_Factory.CreateShip(this.gameObject, GetRelativeAllyPosition());
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
                return (Vector2)this.gameObject.transform.position + new Vector2( pos*2, -pos/2);
            case 4:
                return (Vector2)this.gameObject.transform.position + new Vector2(-pos*2, -pos/2);
            default:
                Debug.LogError("Undefined possibility");
                return Vector2.zero;
        }
    }
}
