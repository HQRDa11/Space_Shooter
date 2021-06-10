using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret 
{
    private float _shotTimerMax;
    private float _shotTimer;

    private Transform _playerTransform;

    private float _xOffset;

    public Turret(GameObject player, float xOffset)
    {
        _shotTimerMax = 0.4f;
        _shotTimer = 0;

        _playerTransform = player.transform;
        _xOffset = xOffset;
    }

    public void Update()
    {
        _shotTimer += Time.deltaTime;
    }

    public void Shoot()
    {
        if (_shotTimer >= _shotTimerMax)
        {
            GameObject newShot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Shot"));
            newShot.transform.position = _playerTransform.position + (Vector3.right * _xOffset) + Vector3.up;
            _shotTimer = 0;
        }
    }
}
