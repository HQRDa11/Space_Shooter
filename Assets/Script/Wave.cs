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

    private List<Vector2> _allCheckPoints;

    private int _enemyRemaining;
    private float _clock = 0;

    public Wave(int numberOfEnemy, int spawnPoint, float spawnDelay, int repeatTimes, float repeatFrequency, int[] checkPoints)
    {
        _numberOfEnemy = numberOfEnemy;
        _spawnPoint = Map.SpawnIndexToPosition(spawnPoint);
        _spawnDelay = spawnDelay;
        _repeatTimes = repeatTimes;
        _repeatFrenquency = repeatFrequency;

        _allCheckPoints = new List<Vector2>();
        foreach (int index in checkPoints) _allCheckPoints.Add(Map.CheckPointIndexToPosition(index));
        _allCheckPoints.Add(Map.DeadzonePoint);

        _enemyRemaining = _numberOfEnemy;
    }
    protected void Initialize()
    {
        _enemyRemaining = _numberOfEnemy;
        _allCheckPoints.Add(Map.DeadzonePoint); 
    }
    public void Update()
    {
        _clock += Time.deltaTime;
        if (_enemyRemaining > 0)
        {
            if (_clock >= _spawnDelay)
            {
                _clock = 0;
                Spawn();
            }
        }
        else if (_repeatTimes > 0)
        {
            if(_clock >= _repeatFrenquency)
            {
                _clock = 0;
                _enemyRemaining = _numberOfEnemy;
                _repeatTimes--;
            }
        }
        else WaveSystem.Instance.NextWave();
    }
    private void Spawn()
    {
        GameObject enemy = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"));
        enemy.transform.position = _spawnPoint;
        enemy.GetComponent<Enemy_Movement>().AllCheckPoints = _allCheckPoints;
        _enemyRemaining--;
    }

}
