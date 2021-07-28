using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Data_TheWorm_Body : Enemy_Data
{
    public Enemy_Data_TheWorm_Body()
    {
        _gameObject = Resources.Load<GameObject>("Prefabs/Enemies/TheWorm_Body");
        _healthBehaviour = new Enemy_Health_Normal();
        _health = 50f;

        _movementBehaviour = new Enemy_Movement_MoveToCheckPoints();
        _moveSpeed = 80f;
        _smoothingSpeed = .3f;
        _wireRadius = .5f;

        _deathBehaviour = new TheWorm_Body_Death();

        _rewardBehaviour = new Enemy_Reward_Normal();
        _scoreReward = 20f;
        _lootChance = 5f;

        _weaponBehaviour = new Enemy_Weapon_MultiShot_Circle(10);
        _shotChance = 100f;
        _shotDamage = 10f;
        _shotFrequency = 0f;
    }
}
