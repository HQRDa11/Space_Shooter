using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TheWorm_Head_Death : Enemy_Behaviours.Death
{
    public void OnDestruction(Enemy enemy)
    {
        List<TheWorm_Body> bodyParts = enemy.GetComponent<TheWorm_Head>().AllBodyPart;

        foreach (TheWorm_Body bodyPart in bodyParts)
        {
            bodyPart.SetDeathBehaviour(new TheWorm_Body_Death_OnHeadDeath());
            bodyPart.OnHeadDeath();
        }

        enemy.RewardBehaviour.GetReward(enemy);
        ComboSystem.Instance.AddCombo();

        Factory.Instance.General_Factory.Create_Explosion(enemy.transform.position);

        GameObject.Destroy(enemy.gameObject);
    }
}
