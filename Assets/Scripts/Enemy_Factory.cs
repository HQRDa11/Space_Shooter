using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Factory
{
    private List<Enemy_Data> _allEnemyDatas;
    private GameObject _inGameObjectsList;

    public Enemy_Factory()
    {
        _allEnemyDatas = new List<Enemy_Data>();
        _allEnemyDatas.Add(new Enemy_Data_Sample());
    }
    public GameObject CreateEnemy(/*Transform parent*/ Vector2 spawnPoint, int index, Wave wave)
    {
        GameObject gameObject = GameObject.Instantiate(_allEnemyDatas[0].GameObject/*parent*/);
        gameObject.transform.position = spawnPoint;
        gameObject.AddComponent<Enemy>().Initialize(new Enemy_Data_Sample(), index, wave);
        gameObject.transform.SetParent(Factory.Instance.InGameObjectsList.transform);
        return gameObject;
    }
}
