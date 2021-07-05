using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon_MultiShot_Spiral : Enemy_Behaviours.Weapon
{
    private int _numberOfShot = 50;
    private int _shotIndex = 0;
    private float _shotAngle = 10f;
    private float _shotDelay = .01f;

    private bool _isFiring;
    private float _clock;
    public void Shoot(Enemy enemy)
    {
        _isFiring = true;
        enemy.CanMove(false);

        if(_clock > _shotDelay)
        {
            _clock = 0;
            float angle = (enemy.transform.eulerAngles.z + _shotAngle * _shotIndex) % 360;
            float rad = Mathf.Deg2Rad * angle;
            Vector2 direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

            GameObject shot = Factory.Instance.Shot_Factory.CreateShot(Factory.Instance.InGameObjectsList, Rarity.WHITE, direction, 2f, "Enemy");
            shot.transform.position = enemy.transform.position;
            _shotIndex++;
        }

        if (_shotIndex == _numberOfShot)
        {
            _isFiring = false;
            enemy.CanMove(true);
            _shotIndex = 0;
        }
    }
    public void ShootOverTime(Enemy enemy)
    {
        _clock += Time.deltaTime;
        if (_isFiring) Shoot(enemy);
    }

}
