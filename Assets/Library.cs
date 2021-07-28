using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library
{
    public static class CheckPointsList
    {
        public static int[] Random(int listSize)
        {
            int[] list = new int[listSize];
            for (int i = 0; i < listSize; i++)
            {
                list[i] = UnityEngine.Random.Range(0, Map.CheckPointDensityWidth * Map.CheckPointDensityHeight - 1);
            }
            return list;
        }
        public static int[] Boss(int bossIndex)
        {
            switch (bossIndex)
            {
                case 0: return Random(50); // A remplacer par une liste fixe

                default: Debug.Log("Unknow Boss Index");
                    break;
            }
            return null;
        }
    }

    public static class WaveList
    {
        public static Wave RandomWave(int difficulty)
        {
            int numberOfEnemy = (int)(Random.Range(5, 10) * Mathf.Sqrt(difficulty));
            int spawnPoint = Random.Range(0, Map.SpawnDensity - 1);
            float spawnDelay = Random.Range(.5f, 2f) / difficulty;
            int repeatTimes = Random.Range(0, 1) * difficulty;
            float repeatFrenquency = Random.Range(3f, 5f) / difficulty;
            int[] checkPoints = Library.CheckPointsList.Random(Random.Range(3, 5) * difficulty);
            bool mirror = Random.Range(0, 100) <= 100 / difficulty ? false : true;

            return new Wave(numberOfEnemy, spawnPoint, spawnDelay, repeatTimes, repeatFrenquency, checkPoints, mirror, new Spawn_RandomSetOnDifficulty()); 
        }
        public static Wave Basic(/*int index*/)
        {
            return null;
        }
        public static Wave Boss(int index)
        {
            switch (index)
            {
                case 1: return new Wave(10 * (WaveSystem.Instance.CurrentWaveIndex / 10), 3, 0f, 0, 0, Library.CheckPointsList.Boss(0), false, new Spawn_TheWorm());

                default: return null;
            }
        }
    }

    public static class EnemyList
    {
        public const int NUMBER_OF_BASIC = 3;
        public const int NUMBER_OF_BOSS = 1;
        public static Enemy_Data GetData(int type, int index)
        {
            switch (type)
            {
                case 1:
                    switch (index)
                    {
                        case 0: return new Enemy_Data_Sample();
                        case 1: return new Enemy_Data_Basic_NormalShot();
                        case 2: return new Enemy_Data_Basic_CircleShot_10();
                        case 3: return new Enemy_Data_Basic_SpiralShot_36();
                        default:
                            Debug.Log("Unknow Basic Enemy Index");
                            return null;
                    }

                case 2:
                    switch (index)
                    {
                        case 0: return new Enemy_Data_Sample();
                        case 1: return new Enemy_Data_TheWorm_Head();
                        default:
                            Debug.Log("Unknow Boss Enemy Head Index");
                            return null;
                    }
                case 3:
                    switch (index)
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
    }
}
