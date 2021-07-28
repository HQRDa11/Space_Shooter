using Enemy_Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement_RandomlyAroundRandomCheckPoint : Enemy_Behaviours.Movement
{
    private Vector2 _currentCheckPointTargeted;
    private Vector2 _currentPointTargeted;
    private Vector2 _velocity = Vector2.zero;

    private float _timeToNextCheckPoint;
    private float _timeToRandomPosition;

    private float _clockToNextCheckPoint;
    private float _clockToRandomPosition;

    public Enemy_Movement_RandomlyAroundRandomCheckPoint()
    {
        _currentCheckPointTargeted = NextCheckPoint();
        _timeToNextCheckPoint = 8f;
        _timeToRandomPosition = 1f;
    }
    public void Move(Enemy enemy)
    {
        _clockToNextCheckPoint += Time.deltaTime;
        _clockToRandomPosition += Time.deltaTime;

        if (_clockToNextCheckPoint >= _timeToNextCheckPoint)
        {
            _clockToNextCheckPoint = 0;
            _currentCheckPointTargeted = NextCheckPoint();
        }
        if (_clockToRandomPosition >= _timeToRandomPosition)
        {
            _clockToRandomPosition = 0;
            _currentPointTargeted = NextTarget();
        }

        enemy.transform.position = Vector2.SmoothDamp(enemy.transform.position, _currentPointTargeted, ref _velocity, enemy.MoveSpeed * Time.deltaTime);
    }
    public Vector2 NextCheckPoint()
    {
        return Map.CheckPointIndexToPosition(Random.Range(0, Map.CheckPointDensity()));
    }
    public Vector2 NextTarget()
    {
        return _currentCheckPointTargeted + new Vector2(Random.Range(0, 100) * .01f, Random.Range(0, 100) * .01f);
    }
    public void Rotation(Enemy enemy)
    {
        // HERE HERE HERE
    }
    public Movement GetNextBehaviour()
    {
        return null;
    }
}
