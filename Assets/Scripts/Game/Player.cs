using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TurretSystem>().Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) == true)
        {
            this.gameObject.GetComponent<TurretSystem>().AddTurret(Factory.Instance.Turret_Factory.CreateRandom());
        }
    }

    public void OnBonus(Rarity rarity)
    {
        Debug.Log("bonus on");
        this.gameObject.GetComponent<TurretSystem>().AddTurret(Factory.Instance.Turret_Factory.CreateTurret(rarity));
    }
}
