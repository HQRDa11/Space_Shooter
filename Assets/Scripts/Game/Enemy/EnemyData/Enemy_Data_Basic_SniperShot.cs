using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Data_Basic_SniperShot : Enemy_Data
{
    public Enemy_Data_Basic_SniperShot()
    {
        _gameObject = Resources.Load<GameObject>("Prefabs/Enemies/Enemy_Basic_Snipershot");
        _healthBehaviour = new Enemy_Health_Normal();
        _health = 20f;

        _movementBehaviour = new Enemy_Movement_FreezeOnCheckPoint();
        _moveSpeed = 70f;
        _smoothingSpeed = .3f;
        _wireRadius = .5f;

        _deathBehaviour = new Enemy_Death_Normal();

        _rewardBehaviour = new Enemy_Reward_Normal();
        _scoreReward = 10f;
        _lootChance = 30f;

        _weaponBehaviour = new Enemy_Weapon_Sniper();
        _shotChance = 20f;
        _shotDamage = 10f;
        _shotFrequency = 0f;
    }
}
