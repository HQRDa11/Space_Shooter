using UnityEngine;

public class Enemy_Movement_MoveToCheckPoints : Enemy_Behaviours.Movement
{
    private int _checkPointIndex = 0;

    private Vector2 _direction = Vector2.zero;
    private Vector2 _velocity = Vector2.zero;
    public void Move(Enemy enemy)
    {
        Vector2 checkPointTargeted = enemy.Wave.AllCheckPoints[_checkPointIndex];
        Vector2 position = enemy.GameObject.transform.position;

        _direction = Vector2.SmoothDamp(
            _direction, 
            (checkPointTargeted - position).normalized, 
            ref _velocity, 
            enemy.SmoothingSpeed);

        enemy.Rigidbody2D.velocity = _direction * enemy.MoveSpeed * Time.deltaTime;

        float distanceFromTarget = Vector2.Distance(position, checkPointTargeted);

        if (distanceFromTarget < enemy.WireRadius) _checkPointIndex++;

        if (_checkPointIndex == enemy.Wave.AllCheckPoints.Count) enemy.SetNextMovementBehaviour();
    }
    public void Rotation(Enemy enemy)
    {
        enemy.Transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(_direction.x, -_direction.y)) * 180 / Mathf.PI;
        enemy.HealthBarTransform.localEulerAngles = new Vector3(0, 0, -Mathf.Atan2(_direction.x, -_direction.y)) * 180 / Mathf.PI;
    }
    public Enemy_Behaviours.Movement GetNextBehaviour()
    {
        return new Enemy_Movement_MoveToIndexPosition();
    }
}
