using UnityEngine;
public class Enemy_Reward_Normal : Enemy_Behaviours.Reward
{
    public void GetReward(Enemy enemy)
    {
        ScoreSystem.Instance.AddScore(enemy.ScoreReward);

        if (Random.Range(0, 100) <= enemy.Lootchance)
        {
            Factory.Instance.Bonus_Factory.Instantiate_DicedBonus(enemy.transform.position);
        }
    }
}
public class Enemy_Reward_Boss : Enemy_Behaviours.Reward
{
    public void GetReward(Enemy enemy)
    {
        ScoreSystem.Instance.AddScore(enemy.ScoreReward);

        for (int i = 0; i < 5; i++)
        {
            GameObject newBonus = Factory.Instance.Bonus_Factory.Instantiate_DicedComponent(enemy.Rarity, enemy.transform.position); ;
            newBonus.transform.position = Map.RandomAround(enemy.transform.position,1f);
        }
    }
}

