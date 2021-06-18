using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret 
{
    private float _shotTimerMax;
    private float _shotTimer;

    private Transform _playerTransform;

    private Rarity _rarity;
    public Rarity Rarity { get=>_rarity; }
    private float _xOffset;

    public Turret(Transform parent, float shotTimerMax, Rarity rarity )
    {
        _shotTimerMax = shotTimerMax;
        _shotTimer = 0;

        _rarity = rarity;

        _playerTransform = parent;
    }

    public void Update()
    {

        _shotTimer += Time.deltaTime;
    }

    public void setOffset(float xOffset)
    {
        _xOffset = xOffset;
    }
    public void Shoot()
    {
        if (_shotTimer >= _shotTimerMax)
        {
            GameObject newShot = Factory.Instance.Shot_Factory.CreateShot(_rarity);
            newShot.transform.position = _playerTransform.position + (Vector3.right * _xOffset) + Vector3.up/2;
            _shotTimer = 0;
        }
    }
}
