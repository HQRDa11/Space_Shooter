using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    protected int _numberOfEnemy;    
    protected Vector2 _spawnPoint;
    protected List<Vector2> _allCheckPoints;
    protected float _spawnDelay;

    protected float _repeatTimes;
    protected float _repeatFrenquency;

    private int _enemyRemaining;
    private float _clock = 0;

    protected void Initialize()
    {
        _enemyRemaining = _numberOfEnemy;
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
        enemy.GetComponent<Enemy_Controller>().AllCheckPoints = _allCheckPoints;
        _enemyRemaining--;
    }
}

public class Wave01 : Wave
{
    public Wave01()
    {
        base._numberOfEnemy = 5;
        base._spawnPoint = Map.SpawnIndexToPosition(2);
        base._allCheckPoints = new List<Vector2>();
        base._spawnDelay = .5f;

        base._repeatTimes = 2;
        base._repeatFrenquency = 2f;

        int[] checkPoints = new int[6] { 0, 11, 12, 23, 24, 35 };
        foreach(int index in checkPoints) base._allCheckPoints.Add(Map.CheckPointIndexToPosition(index));

        base.Initialize();
    }
}

public class Wave02 : Wave
{
    public Wave02()
    {
        base._numberOfEnemy = 10;
        base._spawnPoint = Map.SpawnIndexToPosition(1);
        base._allCheckPoints = new List<Vector2>();
        base._spawnDelay = .5f;

        base._repeatTimes = 1;
        base._repeatFrenquency = 3f;

        int[] checkPoints = new int[6] { 1, 19, 4, 1, 22, 30 };
        foreach(int index in checkPoints) base._allCheckPoints.Add(Map.CheckPointIndexToPosition(index));

        base.Initialize();
    }
}
