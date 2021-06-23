using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int _index;
    private Wave _wave;

    // GAMEOBJECT
    private GameObject _gameObject;
    private Transform _transform;
    private Rigidbody2D _rigidbody2D;

    // HEALTH
    private Enemy_Behaviours.Health _healthBehaviour;
    private float _maxHealth;
    private float _currentHealth;
    private Transform _healthBarTransform;
    private Image _healthBarImage;

    // MOVEMENT
    private Enemy_Behaviours.Movement _movementBehaviour;
    private float _moveSpeed; 
    private float _smoothingSpeed; 
    private float _wireRadius;

    // DEATH
    private Enemy_Behaviours.Death _deathBehaviour;

    // REWARD
    private Enemy_Behaviours.Reward _rewarBehaviour;
    private float _scoreReward;
    private float _lootchance;

    // WEAPON
    private Enemy_Behaviours.Weapon _weaponBehaviour;
    private float _shotChance;
    private float _shotDamage;
    
    public void Initialize(Enemy_Data data, int index, Wave wave)
    {
        _index = index;
        _wave = wave;

        _gameObject =           this.gameObject;
        _transform =            _gameObject.transform;
        _rigidbody2D =          _transform.GetComponent<Rigidbody2D>();

        _healthBehaviour =      data.HealthBehaviour;
        _maxHealth =            EnemyBalance.HealthBalancing(data.Health);
        _currentHealth =        _maxHealth;
        _healthBarTransform =   _transform.Find("CanvasRotationPoint");
        _healthBarImage =       _healthBarTransform.GetComponentInChildren<Image>();

        _movementBehaviour =    data.MovementBehaviour;
        _moveSpeed =            data.MoveSpeed;
        _smoothingSpeed =       data.SmoothingSpeed;
        _wireRadius =           data.WireRadius;

        _deathBehaviour =       data.DeathBehaviour;

        _rewarBehaviour =       data.RewardBehaviour;
        _scoreReward =          data.ScoreReward;
        _lootchance =           data.LootChance;

        _weaponBehaviour =      data.WeaponBehaviour;
        _shotChance =           data.ShotChance;
        _shotDamage =           data.ShotDamage;
    }

    public void Update()
    {
        _healthBehaviour.Health(this);
    }
    private void FixedUpdate()
    {
        _movementBehaviour.Move(this);
        _movementBehaviour.Rotation(this);   
    }
    public void SetNextMovementBehaviour()
    {
        Enemy_Behaviours.Movement next = _movementBehaviour.GetNextBehaviour();
        if (next != null) _movementBehaviour = next;
    }
    public void SetMovementBehaviour(Enemy_Behaviours.Movement movementBehaviour)
    {
        _movementBehaviour = movementBehaviour;
    }
    public void TakeDamage(float damage)
    {
        _currentHealth += _healthBehaviour.TakeDamage(damage);
    }

    // ACCESSORS

    public int Index { get => _index; }
    public Wave Wave { get => _wave; }

    // GameObject
    public GameObject GameObject { get => _gameObject; }
    public Transform Transform { get => _transform; }
    public Rigidbody2D Rigidbody2D { get => _rigidbody2D; }

    // Health
    public Enemy_Behaviours.Health HealthBehaviour { get => _healthBehaviour; }
    public float MaxHealth { get => _maxHealth; }
    public float CurrentHealth { get => _currentHealth; }
    public Transform HealthBarTransform { get => _healthBarTransform; }
    public Image HealthBarImage { get => _healthBarImage; }

    // Movement
    public Enemy_Behaviours.Movement MovementBehaviour { get => _movementBehaviour; }
    public float MoveSpeed { get => _moveSpeed; }
    public float SmoothingSpeed { get => _smoothingSpeed; }
    public float WireRadius { get => _wireRadius; }

    // Death
    public Enemy_Behaviours.Death DeathBehaviour { get => _deathBehaviour; }

    // Reward
    public Enemy_Behaviours.Reward RewardBehaviour { get => _rewarBehaviour; }
    public float ScoreReward { get => _scoreReward; }
    public float Lootchance { get => _lootchance; }

    // Weapon
    public Enemy_Behaviours.Weapon WeaponBehaviour { get => _weaponBehaviour; }
    public float ShotChance { get => _shotChance; }
    public float ShotDamage { get => _shotDamage; }
}
