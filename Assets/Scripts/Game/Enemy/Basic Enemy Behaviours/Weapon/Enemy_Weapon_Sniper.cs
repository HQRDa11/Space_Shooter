using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon_Sniper : Enemy_Behaviours.Weapon
{
    private bool _isShooting;
    private float _shotDelay;

    private float _clock;

    private GameObject _energyAbsorbEffect;
    public Enemy_Weapon_Sniper()
    {
        _isShooting = false;
        _shotDelay = 1f;
    }
    public void Shoot(Enemy enemy)
    {
        if (!_isShooting)
        {
            _isShooting = true;
            _energyAbsorbEffect = Factory.Instance.General_Factory.Create_EnergyAbsorbEffect(enemy.transform);
        }
    }
    public void ShootOverTime(Enemy enemy)
    {
        if (_isShooting)
        {
            _clock += Time.deltaTime;

            if (_clock >= _shotDelay)
            {
                Factory.Instance.Shot_Factory.CreateSniperShot(enemy.Rarity, enemy.ShotDamage, enemy.transform.up, "Enemy", enemy.transform.position);
                GameObject.Destroy(_energyAbsorbEffect);
                _isShooting = false;
                enemy.CanMove(true);
                _clock = 0;

                // Fait reculer le perso
            }
        }
    }
}
