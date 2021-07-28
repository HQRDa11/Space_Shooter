using Enemy_Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement_FreezeOnCheckPoint : Enemy_Behaviours.Movement
{
    private Vector2 _currentCheckPointTargeted;
    private Vector2 _velocity = Vector2.zero;
    private Vector2 _playerDirection;

    private Vector3 _velocity3 = Vector3.zero;
    public Enemy_Movement_FreezeOnCheckPoint()
    {
        _currentCheckPointTargeted = NextCheckPoint();
    }
    public void Move(Enemy enemy)
    {
        _playerDirection = (GameObject.Find("Ship1").transform.position - enemy.transform.position).normalized;

        Vector2 direction = (_currentCheckPointTargeted - (Vector2)enemy.transform.position).normalized;

        enemy.Rigidbody2D.velocity = direction * enemy.MoveSpeed * Time.deltaTime;

        switch (Vector2.Distance(enemy.transform.position, _currentCheckPointTargeted) <= enemy.WireRadius / 10)
        {
            case true:
                enemy.CanMove(false);
                enemy.Shoot();
                enemy.transform.eulerAngles = new Vector3(0, 0, Tools.DirectionToRotation(_playerDirection));
                _currentCheckPointTargeted = NextCheckPoint();
                break;
            case false: break;
        }
    }
    public Vector2 NextCheckPoint()
    {
        return Map.CheckPointIndexToPosition(Random.Range(0, Map.CheckPointDensity()));
    }
    public void Rotation(Enemy enemy)
    {
        enemy.transform.eulerAngles = new Vector3(0, 0, Tools.DirectionToRotation(_playerDirection));
        enemy.HealthBarTransform.localEulerAngles = -enemy.transform.eulerAngles;
    }
    public Movement GetNextBehaviour()
    {
        return null;
    }

}
