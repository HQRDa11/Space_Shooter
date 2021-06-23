using UnityEngine;

public class Enemy_Death_Normal : Enemy_Behaviours.Death
{
    public void OnDestruction(Enemy enemy)
    {
        enemy.RewardBehaviour.GetReward(enemy);
        ComboSystem.Instance.AddCombo();
        GameObject.Destroy(enemy.GameObject);
    }
}
