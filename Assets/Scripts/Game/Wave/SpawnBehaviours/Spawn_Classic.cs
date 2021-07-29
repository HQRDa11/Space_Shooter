using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Classic : SpawnBehaviour
{
    public void Spawn(Wave wave)
    {
        GameObject gameObject1 = Factory.Instance.Enemy_Factory.CreateEnemy(wave.SpawnPoint, wave.AllEnemies.Count + 1, wave, wave.EnemyInstanceClock, ((int)EnemyType.Basic), ((int)BasicEnemy.NormalShot), Factory.Dice_Rarity()) ;
        wave.AllEnemies.Add(gameObject1);
        wave.EnemyRemaining--;
        if ((wave.EnemyRemaining % 2 == 0 && !wave.Mirror) || (wave.EnemyRemaining / 2 % 2 == 0 && wave.Mirror))
        {
            gameObject1.GetComponent<Enemy>().SetWeaponBehaviour(new Enemy_Weapon_MultiShot_Circle(10));
        }

        if (wave.Mirror)
        {
            GameObject gameObject = Factory.Instance.Enemy_Factory.CreateEnemy(wave.SpawnPoint * new Vector2(-1, 1), wave.AllEnemies.Count + 1, wave, wave.EnemyInstanceClock, ((int)EnemyType.Basic), ((int)BasicEnemy.NormalShot),Factory.Dice_Rarity());
            gameObject.GetComponent<Enemy>().SetMovementBehaviour(new Enemy_Movement_MoveToCheckPoints_Mirror());
            wave.AllEnemies.Add(gameObject);
            wave.EnemyRemaining--;
            gameObject.GetComponent<Enemy>().SetWeaponBehaviour(gameObject1.GetComponent<Enemy>().WeaponBehaviour);
        }
    }
}
