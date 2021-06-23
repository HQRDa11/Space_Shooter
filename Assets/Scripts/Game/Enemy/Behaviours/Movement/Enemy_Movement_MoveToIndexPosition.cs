using UnityEngine;

public class Enemy_Movement_MoveToIndexPosition : Enemy_Behaviours.Movement
{
    Vector2 _velocity = Vector2.zero;

    public void Move(Enemy enemy)
    {
        enemy.Rigidbody2D.velocity = Vector2.zero;
        enemy.Transform.position = Vector2.SmoothDamp(
            enemy.Transform.position,
            Map.CheckPointIndexToPosition(enemy.Index),
            ref _velocity,
            enemy.SmoothingSpeed) * Time.deltaTime * enemy.MoveSpeed;
        enemy.Transform.eulerAngles = Vector3.zero;
    }
    public void Rotation(Enemy enemy)
    {
        enemy.HealthBarTransform.localEulerAngles = Vector3.zero;
    }
    public Enemy_Behaviours.Movement GetNextBehaviour()
    {
        return null;
    }
}
