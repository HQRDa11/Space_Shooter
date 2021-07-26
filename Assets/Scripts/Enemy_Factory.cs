using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { NULL = 0, Basic = 1, BossHead = 2, BossBody = 3}
public enum BasicEnemy { NULL = 0, Sample = 1 }
public enum BossHead { NULL = 0, TheWorm = 1 }
public enum BossBody { NULL = 0, TheWorm = 1 }
public class Enemy_Factory
{
    public GameObject CreateEnemy(Vector2 spawnPoint, int index, Wave wave, float time, int type, int libraryIndex)
    {
        Enemy_Data data = GetDataFromLibrary(type, libraryIndex);
        GameObject gameObject = GameObject.Instantiate(data.GameObject, Factory.Instance.InGameObjectsList.transform);
        gameObject.transform.position = spawnPoint;
        //AddComponent(type, libraryIndex, gameObject);
        gameObject.GetComponent<Enemy>().Initialize(data, index, wave, time);
        return gameObject;
    }
    public Enemy_Data GetDataFromLibrary(int type, int libraryIndex)
    {
        switch (type)
        {
            case 1:
                switch (libraryIndex)
                {
                    case 0: return new Enemy_Data_Sample();
                    case 1: return new Enemy_Data_Sample();
                    default: 
                        Debug.Log("Unknow Basic Enemy Index");
                        return null;
                }

            case 2:
                switch (libraryIndex)
                {
                    case 0: return new Enemy_Data_Sample();
                    case 1: return new Enemy_Data_TheWorm_Head(); 
                    default:
                        Debug.Log("Unknow Boss Enemy Head Index");
                        return null;
                }
            case 3:
                switch (libraryIndex)
                {
                    case 0: return new Enemy_Data_Sample();
                    case 1: return new Enemy_Data_TheWorm_Body();
                    default:
                        Debug.Log("Unknow Boss Enemy Body Index");
                        return null;
                }
            default: Debug.Log("Unknow Enemy Type Index"); break;
        }

        return null;
    }

    //public void AddComponent(int type, int libraryIndex, GameObject gameObject)
    //{
    //    switch (type)
    //    {
    //        case 0:
    //            switch (libraryIndex)
    //            {
    //                case 0: gameObject.AddComponent<Basic_Enemy>(); break;

    //                default:
    //                    Debug.Log("Unknow Basic Enemy Index");
    //                    break;
    //            } break;

    //        case 2:
    //            switch (libraryIndex)
    //            {
    //                case 0: gameObject.AddComponent<Boss_Head>(); break;

    //                default:
    //                    Debug.Log("Unknow Boss Head Enemy Index");
    //                    break;
    //            }
    //            break;
    //        case 3:
    //            switch (libraryIndex)
    //            {
    //                case 0: gameObject.AddComponent<Boss_Body>(); break;

    //                default:
    //                    Debug.Log("Unknow Boss Body Index");
    //                    break;
    //            }
    //            break;
    //        default: Debug.Log("Unknow Enemy Type Index"); break;
    //    }        
    //}

}
