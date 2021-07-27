using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Data_Basic_NormalShot : Enemy_Data
{
    public Enemy_Data_Basic_NormalShot()
    {
        _gameObject = Resources.Load<GameObject>("Prefabs/Enemies/Enemy_Basic_NormalShot");
        _healthBehaviour = new Enemy_Health_Normal();
        _health = 20f;

        _movementBehaviour = new Enemy_Movement_MoveToCheckPoints();
        _moveSpeed = 80f;
        _smoothingSpeed = .3f;
        _wireRadius = .5f;

        _deathBehaviour = new Enemy_Death_Normal();

        _rewardBehaviour = new Enemy_Reward_Normal();
        _scoreReward = 10f;
        _lootChance = 30f;

        _weaponBehaviour = new Enemy_Weapon_Normal();
        _shotChance = 20f;
        _shotDamage = 10f;
        _shotFrequency = 3f;
    }
}
