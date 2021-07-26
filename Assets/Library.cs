using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Library
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
}
