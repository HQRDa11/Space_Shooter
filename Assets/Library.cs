using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library
{
    public static class CheckPoints
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

    }

    public static class EnemyData
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
