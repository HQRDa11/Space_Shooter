using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    private int _numberOfEnemy;
    private Vector2 _spawnPoint;
    private float _spawnDelay;

    private float _repeatTimes;
    private float _repeatFrenquency;

    private bool _mirror;

    private List<Vector2> _allCheckPoints;

    private int _enemyRemaining;
    private List<GameObject> _allEnemies;
    private float _clock = 0;

    public Wave(int numberOfEnemy, int spawnPoint, float spawnDelay, int repeatTimes, float repeatFrequency, int[] checkPoints, bool mirror)
    {
        _numberOfEnemy = numberOfEnemy;
        _spawnPoint = Map.SpawnIndexToPosition(spawnPoint);
        _spawnDelay = spawnDelay;
        _repeatTimes = repeatTimes;
        _repeatFrenquency = repeatFrequency;
        _mirror = mirror;
        _allCheckPoints = new List<Vector2>();
        foreach (int index in checkPoints) _allCheckPoints.Add(Map.CheckPointIndexToPosition(index));

        _enemyRemaining = _numberOfEnemy;
        _allEnemies = new List<GameObject>();
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
        else if (_allEnemies.Count == 0)
        {
            if(_repeatTimes > 0 && _clock >= _repeatFrenquency)
            {
                _clock = 0;
                _enemyRemaining = _numberOfEnemy;
                _repeatTimes--;
            } else WaveSystem.Instance.NextWave();
        }       
    }
    private void Spawn()
    {
        GameObject enemy = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"));
        _allEnemies.Add(enemy);
        enemy.transform.position = _spawnPoint;
        enemy.GetComponent<Enemy_Movement>().AllCheckPoints = _allCheckPoints;
        enemy.GetComponent<Enemy_Movement>().Number = _allEnemies.IndexOf(enemy);

        if (_mirror)
        {
            GameObject enemyReverse = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"));
            _allEnemies.Add(enemyReverse);
            enemyReverse.transform.position = new Vector2(-_spawnPoint.x, _spawnPoint.y);
            List<Vector2> allCheckPointReverse = new List<Vector2>();
            foreach (Vector2 vect in _allCheckPoints) allCheckPointReverse.Add(new Vector2(-vect.x, vect.y));
            enemyReverse.GetComponent<Enemy_Movement>().AllCheckPoints = allCheckPointReverse;
            enemyReverse.GetComponent<Enemy_Movement>().Number = _allEnemies.IndexOf(enemyReverse);
        }
        _enemyRemaining--;
    }

}
