using UnityEngine;

public class Enemy_Death_Normal : Enemy_Behaviours.Death
{
    public void OnDestruction(Enemy enemy)
    {
        enemy.RewardBehaviour.GetReward(enemy);
        ComboSystem.Instance.AddCombo();

        GameObject explosion = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"));
        explosion.transform.position = enemy.transform.position;

        GameObject.Destroy(enemy.gameObject);
    }
}
