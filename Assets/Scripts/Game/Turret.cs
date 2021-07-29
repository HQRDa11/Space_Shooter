using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret 
{
    private float _shotTimerMax;
    private float _shotTimer;

    private Rarity _rarity;
    public Rarity Rarity { get=>_rarity; }

    public TurretSlot m_slot;
    public TurretSlot Slot { get => m_slot; set { m_slot = value; } }

    public Turret( float shotTimerMax, Rarity rarity )
    {
        _shotTimerMax = shotTimerMax;
        _shotTimer = 0;
        _rarity = rarity;
    }

    public void Update()
    {

        _shotTimer += Time.deltaTime;
    }

    public void Shoot()
    {
        if (_shotTimer >= _shotTimerMax)
        {
           // Debug.Log("ShotDamage: " + m_slot.Damage);
            GameObject newShot = Factory.Instance.Shot_Factory.CreateShot(m_slot.transform,_rarity,m_slot.Damage,Vector2.up,10f,"Player");
            newShot.transform.position = (Vector2)m_slot.transform.position + new Vector2(0f,0.1f) ;
            _shotTimer = 0;
        }
    }

}
