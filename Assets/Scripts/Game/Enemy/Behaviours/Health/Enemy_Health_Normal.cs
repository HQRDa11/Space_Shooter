public class Enemy_Health_Normal : Enemy_Behaviours.Health
{
    public void Health(Enemy enemy)
    {
        enemy.HealthBarImage.fillAmount = enemy.CurrentHealth / enemy.MaxHealth;
    }
    public float TakeDamage(float damage)
    {
        return damage;
    }
}
