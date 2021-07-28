using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    private int _numberOfEnemy; public int NumberOfEnemy { get => _numberOfEnemy; }
    private int _enemyRemaining; public int EnemyRemaining { get => _enemyRemaining; set => _enemyRemaining = value; }
    private Vector2 _spawnPoint; public Vector2 SpawnPoint { get => _spawnPoint; }
    private float _spawnDelay;

    private float _repeatTimes;
    private float _repeatFrequency;

    private bool _mirror; public bool Mirror { get => _mirror; }

    private List<Vector2> _allCheckPoints; public List<Vector2> AllCheckPoints { get => _allCheckPoints; } // <<<< Remplacer par class de List de checkpoints dans wave system

    private List<GameObject> _allEnemies; public List<GameObject> AllEnemies { get => _allEnemies; }

    private float _enemyInstanceClock; public float EnemyInstanceClock { get => _enemyInstanceClock; }
    private int _enemyIndex; public int EnemyIndex { get => _enemyIndex; set { _enemyIndex = value; Debug.Log("Index > " + EnemyIndex); }  }

    private SpawnBehaviour _spawnBehaviour;
    private float _clock = 0;
    public Wave(int numberOfEnemy, int spawnPoint, float spawnDelay, int repeatTimes, float repeatFrequency, int[] checkPoints, bool mirror, SpawnBehaviour spawnBehaviour)
    {
        _numberOfEnemy =        numberOfEnemy;
        _spawnPoint =           Map.SpawnIndexToPosition(spawnPoint);
        _spawnDelay =           spawnDelay;
        _repeatTimes =          repeatTimes;
        _repeatFrequency =      repeatFrequency;
        _mirror =               mirror;
        _spawnBehaviour =       spawnBehaviour;

        _allCheckPoints =       new List<Vector2>();
        foreach (int index in checkPoints) _allCheckPoints.Add(Map.CheckPointIndexToPosition(index));

        _enemyInstanceClock = 0;
        _enemyIndex = 0;

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
                _spawnBehaviour.Spawn(this);
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
}
