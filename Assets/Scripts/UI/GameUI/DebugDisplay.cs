using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

public class DebugDisplay : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // MAP
        // Spawn's positions
        for (int i = 0; i < Map.SpawnDensity; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(Map.SpawnIndexToPosition(i), Vector3.one / 2);
        }

        for (int i = 0; i < Map.CheckPointDensityWidth * Map.CheckPointDensityHeight; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Map.CheckPointIndexToPosition(i), .5f);
        }
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G)) OrderBy(RandomArrayOfInt());
    }

    public int[] RandomArrayOfInt()
    {
        int[] intArray = new int[Random.Range(10, 50)];
        for(int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = Random.Range(0, 30);
        }

        return intArray;
    }
    public void OrderBy(int[] intArray)
    {
        List<int> list = new List<int>();
        list = intArray.ToList();


        List<int> orderedList = new List<int>();

        while(list.Count > 0)
        {
            orderedList.Add(list.Min());
            list.Remove(list.Min());
        }

        int[] arrayToReturn = new int[orderedList.Count];

        for(int i = 0; i < orderedList.Count; i++)
        {
            if (i == 0) arrayToReturn[0] = orderedList[0];

            else
            {
                if (i % 2 == 0) arrayToReturn[0 + i / 2] = orderedList[i];
                else arrayToReturn[arrayToReturn.Length - 1 - i / 2] = orderedList[i];
            }
        }

        foreach (int i in arrayToReturn) Debug.Log(i);
    }
}
