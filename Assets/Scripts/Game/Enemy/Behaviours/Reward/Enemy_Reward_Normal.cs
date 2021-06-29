using UnityEngine;
public class Enemy_Reward_Normal : Enemy_Behaviours.Reward
{
    public void GetReward(Enemy enemy)
    {
        ScoreSystem.Instance.AddScore(enemy.ScoreReward);

        if (Random.Range(0, 100) <= enemy.Lootchance)
        {
            Factory.Instance.Bonus_Factory.Instantiate_RandomBonus(enemy.transform.position);
        }
    }
}