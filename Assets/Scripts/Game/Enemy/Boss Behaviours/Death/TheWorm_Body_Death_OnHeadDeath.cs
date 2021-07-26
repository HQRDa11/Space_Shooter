using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorm_Body_Death_OnHeadDeath : Enemy_Behaviours.Death
{
    public void OnDestruction(Enemy enemy)
    {
        enemy.Shoot();

        enemy.RewardBehaviour.GetReward(enemy);
        ComboSystem.Instance.AddCombo();

        Factory.Instance.General_Factory.Create_Explosion(enemy.transform.position);

        GameObject.Destroy(enemy.gameObject);
    }
}
