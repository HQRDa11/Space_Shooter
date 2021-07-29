using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Data_TheWorm_Head : Enemy_Data
{
    public Enemy_Data_TheWorm_Head()
    {
        _gameObject = Resources.Load<GameObject>("Prefabs/Enemies/TheWorm_Head");
        _healthBehaviour = new Enemy_Health_Normal();
        _health = 1000f;

        _movementBehaviour = new Enemy_Movement_MoveToCheckPoints();
        _moveSpeed = 80f;
        _smoothingSpeed = .3f;
        _wireRadius = .5f;

        _deathBehaviour = new TheWorm_Head_Death();

        _rewardBehaviour = new Enemy_Reward_Boss(); // < A remplacer par une recompense special TheWorm
        _scoreReward = 100f;
        _lootChance = 30f;

        _weaponBehaviour = new Enemy_Weapon_NoWeapon();
        _shotChance = 0f;
        _shotDamage = 0f;
        _shotFrequency = 0f;
    }
}
