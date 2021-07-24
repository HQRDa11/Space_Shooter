using UnityEngine;
public class Enemy_Health_Normal : Enemy_Behaviours.Health
{
    public void Health(Enemy enemy)
    {
        enemy.HealthBarImage.fillAmount = enemy.CurrentHealth / enemy.MaxHealth;
        if(enemy.CurrentHealth <= 0)
        {
            enemy.OnDestruction();
        }
    }
    public double TakeDamage(double damage)
    {
        Debug.Log("Damage Dealt:" + damage);
        return damage;
    }
}
