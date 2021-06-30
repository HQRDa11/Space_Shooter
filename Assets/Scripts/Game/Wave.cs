using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    private int _numberOfEnemy;
    private Vector2 _spawnPoint;
    private float _spawnDelay;

    private float _repeatTimes;
    private float _repeatFrequency;

    private bool _mirror;

    private List<Vector2> _allCheckPoints; public List<Vector2> AllCheckPoints { get => _allCheckPoints; } // <<<< Remplacer par class de List de checkpoints dans wave system

    private int _enemyRemaining;
    private List<GameObject> _allEnemies;

    private float _enemyInstanceClock;

    private float _clock = 0;
    public Wave(int numberOfEnemy, int spawnPoint, float spawnDelay, int repeatTimes, float repeatFrequency, int[] checkPoints, bool mirror)
    {
        _numberOfEnemy = numberOfEnemy;
        _spawnPoint = Map.SpawnIndexToPosition(spawnPoint);
        _spawnDelay = spawnDelay;
        _repeatTimes = repeatTimes;
        _repeatFrequency = repeatFrequency;
        _mirror = mirror;
        _allCheckPoints = new List<Vector2>();
        foreach (int index in checkPoints) _allCheckPoints.Add(Map.CheckPointIndexToPosition(index));

        _enemyRemaining = _numberOfEnemy;
        _allEnemies = new List<GameObject>();
    }
    public void Update()
    {
        _enemyInstanceClock += Time.deltaTime;

        _allEnemies.RemoveAll(enemy => enemy == null);
        _clock += Time.deltaTime;

        if (_enemyRemaining > 0)
        {
            if (_clock >= _spawnDelay)
            {
                _clock = 0;
                Spawn();
            }
        }
        else if (_repeatTimes > 0 && _clock >= _repeatFrequency && _allEnemies.Count == 0)
        {
            _clock = 0;
            _enemyRemaining = _numberOfEnemy;
            _repeatTimes--;            
        }       
        else if (_allEnemies.Count == 0) WaveSystem.Instance.NextWave();
    }
private void Spawn()
    {
        // UPDATE la _instanceClock DANS Update()

        // SET la Clock de l'ennemi a l'instanciation
        // >> VOIR Enemy Class

        // FAIRE un switch dans la factory pour pouvoir Set Weapon Behaviour avec Index; <<<<<<<<<<<<<<<<<<<<<<<<

        GameObject gameObject1 = Factory.Instance.Enemy_Factory.CreateEnemy(_spawnPoint, _allEnemies.Count + 1, this, _enemyInstanceClock);
        _allEnemies.Add(gameObject1);
        _enemyRemaining--;
        if((_enemyRemaining % 2 == 0 && !_mirror) || (_enemyRemaining / 2 % 2 == 0 && _mirror))
        {
            gameObject1.GetComponent<Enemy>().SetWeaponBehaviour(new Enemy_Weapon_MultiShot_Circle());
        }

        if (_mirror)
        {
            GameObject gameObject = Factory.Instance.Enemy_Factory.CreateEnemy(_spawnPoint * new Vector2(-1, 1), _allEnemies.Count + 1, this, _enemyInstanceClock);
            gameObject.GetComponent<Enemy>().SetMovementBehaviour(new Enemy_Movement_MoveToCheckPoints_Mirror());
            _allEnemies.Add(gameObject);
            _enemyRemaining--;
            gameObject.GetComponent<Enemy>().SetWeaponBehaviour(gameObject1.GetComponent<Enemy>().WeaponBehaviour);
        }
    }
}
