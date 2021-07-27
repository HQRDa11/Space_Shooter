using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { NULL = 0, Basic = 1, BossHead = 2, BossBody = 3}
public enum BasicEnemy { NULL = 0, NormalShot = 1, CircleShot_10 = 2, SpiralShot_36 = 3 }
public enum BossHead { NULL = 0, TheWorm = 1 }
public enum BossBody { NULL = 0, TheWorm = 1 }
public class Enemy_Factory
{
    public GameObject CreateEnemy(Vector2 spawnPoint, int index, Wave wave, float time, int type, int libraryIndex)
    {
        Enemy_Data data = Library.EnemyList.GetData(type, libraryIndex);
        GameObject gameObject = GameObject.Instantiate(data.GameObject, Factory.Instance.InGameObjectsList.transform);
        gameObject.transform.position = spawnPoint;
        gameObject.GetComponent<Enemy>().Initialize(data, index, wave, time);
        
        return gameObject;
    }
}
