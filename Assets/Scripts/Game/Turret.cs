using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret 
{
    private float _shotTimerMax;
    private float _shotTimer;

    private Rarity _rarity;
    public Rarity Rarity { get=>_rarity; }
    public Transform SlotTransform { get; set; }

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
            GameObject newShot = Factory.Instance.Shot_Factory.CreateShot(_rarity);
            newShot.transform.position = (Vector2)SlotTransform.position + new Vector2(0f,0.1f) ;
            _shotTimer = 0;
        }
    }
}
