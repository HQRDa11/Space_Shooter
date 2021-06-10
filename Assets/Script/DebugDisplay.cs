using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Map.CheckPointIndexToPosition(35), 1);
    }
}
