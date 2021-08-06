using UnityEngine;

public class Enemy_Movement_MoveToCheckPoints_Mirror : Enemy_Behaviours.Movement
{
    private Vector2 _velocity = Vector2.zero;
    private bool _firstUpdate;
    public void Move(Enemy enemy)
    {
        Vector2 checkPointTargeted = enemy.Wave.AllCheckPoints[enemy.CheckPointIndex] * new Vector2(-1, 1);
        Vector2 position = enemy.transform.position;

        if (!_firstUpdate)
        {
            _firstUpdate = true;
            enemy.MoveDirection = (checkPointTargeted - position).normalized;
        }

        enemy.MoveDirection = Vector2.SmoothDamp(
            enemy.MoveDirection,
            (checkPointTargeted - position).normalized,
            ref _velocity,
            enemy.SmoothingSpeed);

        enemy.transform.position += (Vector3)enemy.MoveDirection * enemy.MoveSpeed * Time.deltaTime;

        float distanceFromTarget = Vector2.Distance(position, checkPointTargeted);

        if (distanceFromTarget < enemy.WireRadius)
        {
            enemy.CheckPointIndex++;
        }

        if (enemy.CheckPointIndex == enemy.Wave.AllCheckPoints.Count)
        {
            enemy.SetWeaponBehaviour(new Enemy_Weapon_RandomShot());
            enemy.SetNextMovementBehaviour();
        }
    }
    public void Rotation(Enemy enemy)
    {
        enemy.transform.eulerAngles = new Vector3(0, 0, Tools.DirectionToRotation(enemy.MoveDirection));
        enemy.HealthBarTransform.localEulerAngles = new Vector3(0, 0, -Tools.DirectionToRotation(enemy.MoveDirection));
    }
    public Enemy_Behaviours.Movement GetNextBehaviour()
    {
        return new Enemy_Movement_MoveToIndexPosition();
    }
}
