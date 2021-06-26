using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Factory
{
    private List<Enemy_Data> _allEnemyDatas = new List<Enemy_Data>();

    public Enemy_Factory()
    {
        _allEnemyDatas.Add(new Enemy_Data_Sample());
    }
    public GameObject CreateEnemy(/*Transform parent*/ Vector2 spawnPoint, int index, Wave wave)
    {
        GameObject gameObject = GameObject.Instantiate(_allEnemyDatas[0].GameObject/*parent*/);
        gameObject.transform.position = spawnPoint;
        gameObject.AddComponent<Enemy>().Initialize(new Enemy_Data_Sample(), index, wave);

        return gameObject;
    }
}
