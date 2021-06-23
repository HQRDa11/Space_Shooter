using UnityEngine;

public class Enemy_Data_Sample : Enemy_Data
{
    public Enemy_Data_Sample()
    {
        _gameObject = Resources.Load<GameObject>("Your GameObject Path");
        _healthBehaviour = new Enemy_Health_Normal();
        _health = 20f;

        _movementBehaviour = new Enemy_Movement_MoveToCheckPoints();
        _moveSpeed = 150f;
        _smoothingSpeed = .3f;
        _wireRadius = 1.5f;

        _deathBehaviour = new Enemy_Death_Normal();

        _rewardBehaviour = new Enemy_Reward_Normal();
        _scoreReward = 10f;
        _lootChance = 10f;

        _weaponBehaviour = new Enemy_Weapon_Normal();
        _shotChance = 20f;
        _shotDamage = 10f;
    }
}
