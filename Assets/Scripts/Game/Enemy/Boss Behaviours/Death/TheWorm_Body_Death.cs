using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TheWorm_Body_Death : Enemy_Behaviours.Death
{
    public void OnDestruction(Enemy enemy)
    {
        enemy.Shoot();
        Transform.FindObjectOfType<TheWorm_Head>().OnBodyPartDeath(enemy.GetComponent<TheWorm_Body>());

        enemy.RewardBehaviour.GetReward(enemy);
        ComboSystem.Instance.AddCombo();

        Factory.Instance.General_Factory.Create_Explosion(enemy.transform.position);

        GameObject.Destroy(enemy.gameObject);
    }
}
