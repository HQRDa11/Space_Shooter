using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_OnDifficulty : SpawnBehaviour
{
    public void Spawn(Wave wave)
    {
        for (int i = 1; i <= Library.EnemyList.NUMBER_OF_BASIC; i++)
        {
            if (i == 1)
            {
                GameObject gameObject1 = Factory.Instance.Enemy_Factory.CreateEnemy(wave.SpawnPoint, wave.AllEnemies.Count + 1, wave, wave.EnemyInstanceClock, ((int)EnemyType.Basic), i);
                wave.AllEnemies.Add(gameObject1);
                wave.EnemyRemaining--;

                if (wave.Mirror)
                {
                    GameObject gameObject2 = Factory.Instance.Enemy_Factory.CreateEnemy(wave.SpawnPoint * new Vector2(-1, 1), wave.AllEnemies.Count + 1, wave, wave.EnemyInstanceClock, ((int)EnemyType.Basic), i);
                    gameObject2.GetComponent<Enemy>().SetMovementBehaviour(new Enemy_Movement_MoveToCheckPoints_Mirror());
                    wave.AllEnemies.Add(gameObject2);
                    wave.EnemyRemaining--;
                }
            }
            else if (Random.Range(0, 100) < 100 / i * WaveSystem.Instance.CurrentWaveIndex / 100)
            {
                GameObject gameObject3 = Factory.Instance.Enemy_Factory.CreateEnemy(wave.SpawnPoint, wave.AllEnemies.Count + 1, wave, wave.EnemyInstanceClock, ((int)EnemyType.Basic), i);
                wave.AllEnemies.Add(gameObject3);
                wave.EnemyRemaining--;
            }
        }
    }
}
