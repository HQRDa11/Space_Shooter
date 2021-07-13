using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

public class DebugDisplay : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        //// MAP
        //// Spawn's positions
        //for (int i = 0; i < Map.SpawnDensity; i++)
        //{
        //    Gizmos.color = Color.green;
        //    Gizmos.DrawWireCube(Map.SpawnIndexToPosition(i), Vector3.one / 2);
        //}
        //// CheckPoint's position
        //for (int i = 0; i < Map.CheckPointDensityWidth * Map.CheckPointDensityHeight; i++)
        //{
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawWireSphere(Map.CheckPointIndexToPosition(i), .5f);
        //}
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.G)) Debug.Log("No Debug is assigned");
    }

    public void AngleTester()
    {
        
        for(int i = 0; i < 360; i += 30)
        {
            float rad = Mathf.Deg2Rad * i;
            float cos = Mathf.Cos(rad);
            float sin = Mathf.Sin(rad);

            Vector2 dir = new Vector2(cos, sin);

            Debug.Log("Angle > " + i + " = Vector2 > " + dir);
            if (i / 10 % 2 == 0) Debug.DrawRay(Vector2.zero, dir * (i + 10) / 10, Color.red, 10f);
            else Debug.DrawRay(Vector2.zero, dir * (i + 10) / 10, Color.blue, 10f);
        }
    }
}
