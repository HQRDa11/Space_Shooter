using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_TheWorm : SpawnBehaviour
{
    TheWorm_Head head;
    GameObject gameObject;

    public void Spawn(Wave wave)
    {
        wave.EnemyRemaining = 0;

        for (int i = 0; i < wave.NumberOfEnemy; i++)
        {
            if (i == 0)
            {
                gameObject = Factory.Instance.Enemy_Factory.CreateEnemy(wave.SpawnPoint, wave.AllEnemies.Count + 1, wave, wave.EnemyInstanceClock, ((int)EnemyType.BossHead), ((int)BossHead.TheWorm));
                gameObject.GetComponent<Enemy>().CanShoot(false);
                head = gameObject.GetComponent<TheWorm_Head>();
                wave.AllEnemies.Add(gameObject);    
            }
            else
            {
                gameObject = Factory.Instance.Enemy_Factory.CreateEnemy(wave.SpawnPoint, wave.AllEnemies.Count + 1, wave, wave.EnemyInstanceClock, ((int)EnemyType.BossBody), ((int)BossBody.TheWorm));
                gameObject.GetComponent<Enemy>().CanShoot(false);
                head.AllBodyPart.Add(gameObject.GetComponent<TheWorm_Body>());
                wave.AllEnemies.Add(gameObject);
            }            
        }
    }
}
