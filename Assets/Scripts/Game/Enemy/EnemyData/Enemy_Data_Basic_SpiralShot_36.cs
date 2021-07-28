using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Data_Basic_SpiralShot_36 : Enemy_Data
{
    public Enemy_Data_Basic_SpiralShot_36()
    {
        _gameObject = Resources.Load<GameObject>("Prefabs/Enemies/Enemy_Basic_SpiralShot_36");
        _healthBehaviour = new Enemy_Health_Normal();
        _health = 40f;

        _movementBehaviour = new Enemy_Movement_RandomlyAroundRandomCheckPoint();
        _moveSpeed = 100f;
        _smoothingSpeed = .3f;
        _wireRadius = .5f;

        _deathBehaviour = new Enemy_Death_Normal();

        _rewardBehaviour = new Enemy_Reward_Normal();
        _scoreReward = 20f;
        _lootChance = 5f;

        _weaponBehaviour = new Enemy_Weapon_MultiShot_Spiral(36);
        _shotChance = 100f;
        _shotDamage = 10f;
        _shotFrequency = 5f;
    }
}
