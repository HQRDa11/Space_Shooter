using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { NULL = 0, Basic = 1, BossHead = 2, BossBody = 3 }
public enum BasicEnemy { NULL = 0, NormalShot = 1, CircleShot_10 = 2, SpiralShot_36 = 3, Lenght }
public enum BossHead { NULL = 0, TheWorm = 1, Lenght }
public enum BossBody { NULL = 0, TheWorm = 1 }
public class Enemy_Factory
{
    public GameObject CreateEnemy(Vector2 spawnPoint, int index, Wave wave, float time, int type, int libraryIndex)
    {
        Enemy_Data data = Library.EnemyList.GetData(type, libraryIndex);
        GameObject newEnemy = GameObject.Instantiate(data.GameObject, Factory.Instance.InGameObjectsList.transform);
        newEnemy.transform.position = spawnPoint;
        newEnemy.GetComponent<Enemy>().Initialize(data, index, wave, time);
        newEnemy.GetComponent<Enemy>().Set_Rarity(Factory.Dice_Rarity());
        return newEnemy;
    }

    // HOW TO CREATE A NEW ENEMY 

    // > Copy Enemy prefabs
    // - Rename it
    // - Set Scale
    // - Change Sprite
    // - Replace Enemy script (Create new one if you need a special behaviour, who's extending Basic_Enemy, Boss_Head or Boss_Body)
    // - Drag it to Prefabs/Enemies THEN click on "Original Prefab"

    // > Create your Enemy_Data
    // - You can create new behaviour who's extending Enemy_Behaviours

    // > Add Enemy_Data to the Library

    // > Add Enemy's name to the Enum List in Enemy_Factory (For BOSS with a body, they must have the same Enum Index)
}
