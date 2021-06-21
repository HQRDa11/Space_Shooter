using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Ship ship; // not done yet

    // Ally system
    private List<Ally> m_allAllies;
    private int m_maxAllies;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TurretSystem>().Initialise();

        m_maxAllies = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T) == true)
        //{
        //    this.gameObject.GetComponent<TurretSystem>().AddTurret(Factory.Instance.Turret_Factory.CreateRandom());
        //}
    }

    public void OnTurretBonus(Rarity rarity)
    {
        Debug.Log("bonus on");
        this.gameObject.GetComponent<TurretSystem>().AddTurret(Factory.Instance.Turret_Factory.CreateTurret(rarity));
    }
    public void OnPilotBonus()
    {
        Debug.LogWarning("Pilot Bonus : not implemented yet");
    }
}
