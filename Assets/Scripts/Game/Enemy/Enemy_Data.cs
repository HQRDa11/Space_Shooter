using UnityEngine;

public class Enemy_Data
{
    // GAMEOBJECT
    protected GameObject _gameObject;

    // HEALTH
    protected Enemy_Behaviours.Health _healthBehaviour;
    protected float _health;

    // MOVEMENT
    protected Enemy_Behaviours.Movement _movementBehaviour;
    protected float _moveSpeed, _smoothingSpeed, _wireRadius;

    // DEATH
    protected Enemy_Behaviours.Death _deathBehaviour;

    // REWARD
    protected Enemy_Behaviours.Reward _rewardBehaviour;
    protected float _scoreReward, _lootChance;

    // WEAPON
    protected Enemy_Behaviours.Weapon _weaponBehaviour;
    protected float _shotChance, _shotDamage, _shotFrequency;


    // ACCESS
    public GameObject GameObject { get => _gameObject; }
    public Enemy_Behaviours.Health HealthBehaviour { get => _healthBehaviour; }
    public float Health { get => _health; }
    public Enemy_Behaviours.Movement MovementBehaviour { get => _movementBehaviour; }
    public float MoveSpeed { get => _moveSpeed; }
    public float SmoothingSpeed { get => _smoothingSpeed; }
    public float WireRadius { get => _wireRadius; }
    public Enemy_Behaviours.Death DeathBehaviour { get => _deathBehaviour; }
    public Enemy_Behaviours.Reward RewardBehaviour { get => _rewardBehaviour; }
    public float ScoreReward { get => _scoreReward; }
    public float LootChance { get => _lootChance; }
    public Enemy_Behaviours.Weapon WeaponBehaviour { get => _weaponBehaviour; }
    public float ShotChance { get => _shotChance; }
    public float ShotDamage { get => _shotDamage; }
    public float ShotFrequency { get => _shotFrequency; }
}
