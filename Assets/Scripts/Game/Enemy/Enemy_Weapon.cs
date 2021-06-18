using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon : MonoBehaviour
{
    [SerializeField]
    private float _shotChance;
    public void Shoot()
    {
        if(!GetComponent<Enemy_Movement>().IsAtLastCheckPoint) Debug.Log("The enemy fired !");
        else
        {
            if(Random.Range(0, 100) < _shotChance) /*Debug.Log("The enemy fired !")*/;
        }
    }

    public void SetShotChance(float shotChance)
    {
        _shotChance = shotChance;
    }
}
