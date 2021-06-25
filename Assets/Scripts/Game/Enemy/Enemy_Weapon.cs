using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon : MonoBehaviour
{
    [SerializeField]
    private float _shotChance;
    public bool TryShooting()
    {
        if (!GetComponent<Enemy_Movement>().IsAtLastCheckPoint)
        {
            Shoot();
            return true;
        }
        else
        {
            if(Random.Range(0, 100) < _shotChance)
            {
                Shoot();
                return true;
            }
        }
        return false;
    }

    public void SetShotChance(float shotChance)
    {
        _shotChance = shotChance;
    }

    public void Shoot()
    {
        GameObject shot = Factory.Instance.Shot_Factory.CreateShot(this.gameObject.transform, Rarity.WHITE, transform.rotation * Vector2.up, 3f, "Enemy"); ;
        shot.transform.position = this.gameObject.transform.position;
    }
}
