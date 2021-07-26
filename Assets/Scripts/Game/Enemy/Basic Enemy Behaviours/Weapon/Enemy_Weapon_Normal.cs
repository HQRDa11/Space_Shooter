using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon_Normal : Enemy_Behaviours.Weapon
{
    public void Shoot(Enemy enemy)
    {
        GameObject shot = Factory.Instance.Shot_Factory.Create_DefaultEnemyShot(enemy.transform.rotation * Vector2.up);

        shot.transform.position = enemy.transform.position;
    }
    public void ShootOverTime(Enemy enemy) { }

}
