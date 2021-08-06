using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement_MoveToCheckPoints_Infinity_WithoutSmoothdamp : Enemy_Behaviours.Movement
{
    public void Move(Enemy enemy)
    {
        Vector2 checkPointTargeted = enemy.Wave.AllCheckPoints[enemy.CheckPointIndex];
        Vector2 position = enemy.transform.position;

        enemy.MoveDirection = (checkPointTargeted - position).normalized;

        enemy.transform.position += (Vector3)enemy.MoveDirection * enemy.MoveSpeed * Time.deltaTime;

        float distanceFromTarget = Vector2.Distance(position, checkPointTargeted);

        if (distanceFromTarget < enemy.WireRadius)
        {
            enemy.CheckPointIndex++;
        }
        if (enemy.CheckPointIndex == enemy.Wave.AllCheckPoints.Count)
        {
            enemy.CheckPointIndex = 1;
        }
    }
    public void Rotation(Enemy enemy)
    {
        enemy.transform.eulerAngles = new Vector3(0, 0, Tools.DirectionToRotation(enemy.MoveDirection));
        enemy.HealthBarTransform.localEulerAngles = new Vector3(0, 0, -Tools.DirectionToRotation(enemy.MoveDirection));
    }
    public Enemy_Behaviours.Movement GetNextBehaviour()
    {
        return null;
    }
}
