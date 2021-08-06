using UnityEngine;

public class Enemy_Movement_MoveToIndexPosition : Enemy_Behaviours.Movement
{
    Vector2 _velocity = Vector2.zero;

    public void Move(Enemy enemy)
    {
        enemy.Rigidbody2D.velocity = Vector2.zero;
        
        enemy.transform.position = Vector2.SmoothDamp(
            enemy.transform.position,
            Map.CheckPointIndexToPosition(enemy.Index),
            ref _velocity,
            enemy.SmoothingSpeed);
    }
    public void Rotation(Enemy enemy)
    {
        enemy.transform.eulerAngles = new Vector3(0, 0, 180);
        enemy.HealthBarTransform.localEulerAngles = new Vector3(0, 0, 180);
    }
    public Enemy_Behaviours.Movement GetNextBehaviour()
    {
        return null;
    }
}
