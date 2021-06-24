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
    private float _clock = 0;

    private float _shotClock;
    private float _shotFrequency;
    public Wave(int numberOfEnemy, int spawnPoint, float spawnDelay, int repeatTimes, float repeatFrequency, int[] checkPoints, bool mirror, float shotFrequency)
    {
        _numberOfEnemy = numberOfEnemy;
        _spawnPoint = Map.SpawnIndexToPosition(spawnPoint);
        _spawnDelay = spawnDelay;
        _repeatTimes = repeatTimes;
        _repeatFrequency = repeatFrequency;
        _mirror = mirror;
        _allCheckPoints = new List<Vector2>();
        foreach (int index in checkPoints) _allCheckPoints.Add(Map.CheckPointIndexToPosition(index));
        GameObject gameObject = GameObject.Find("Circle");
        foreach(Vector2 vect in _allCheckPoints)
        {
            GameObject mark = GameObject.Instantiate(gameObject);
            mark.transform.position = vect;

        }
        _enemyRemaining = _numberOfEnemy;
        _allEnemies = new List<GameObject>();

        _shotFrequency = shotFrequency;
    }
    public void Update()
    {
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

        EnemyShot();
    }
private void Spawn()
    {

        _allEnemies.Add(Factory.Instance.Enemy_Factory.CreateEnemy(_spawnPoint, _allEnemies.Count + 1, this));
        
        if (_mirror)
        {
            GameObject gameObject = Factory.Instance.Enemy_Factory.CreateEnemy(_spawnPoint, _allEnemies.Count + 1, this);
            gameObject.GetComponent<Enemy>().SetMovementBehaviour(new Enemy_Movement_MoveToCheckPoints_Mirror());
            _enemyRemaining--;
        }
        _enemyRemaining--;
    }

    private void EnemyShot()
    {
        _shotClock += Time.deltaTime;

        if(_shotClock >= _shotFrequency)
        {
            foreach(GameObject gameObject in _allEnemies)
            {
                gameObject.GetComponent<Enemy>().Shoot();
            }

            _shotClock = 0;
        }
    }
}
