using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General_Factory
{
    private GameObject _explosionAnim;

    public General_Factory()
    {
        _explosionAnim = Resources.Load<GameObject>("Prefabs/Explosion");
    }

    public void Create_Deposit(double life, double size, Vector3 position)
    {
        Deposit deposit = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Deposit")).GetComponent<Deposit>();
        switch (deposit == null)
        {
            case true: Debug.LogError("error: cant instantiate new deposite"); return;

            case false:
                deposit.gameObject.transform.position = position;
                deposit.gameObject.transform.localScale *= (float)size / 3;
                deposit.Initialise(life, size);
                break;
        }
    }

    public void Create_Explosion(Vector3 position)
    {
        GameObject explosion = GameObject.Instantiate(_explosionAnim);
        explosion.transform.position = position;
    }
    public GameObject Create_EnergyAbsorbEffect(Transform parent)
    {
        return GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/EnergyAbsorbEffect"), parent);
    }
}
