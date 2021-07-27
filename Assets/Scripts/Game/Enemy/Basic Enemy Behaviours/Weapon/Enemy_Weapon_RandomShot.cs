using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon_RandomShot : Enemy_Behaviours.Weapon
{
    public void Shoot(Enemy enemy)
    {
        if (Random.Range(0, 100) < enemy.ShotChance)
        {
            Vector3 direction = enemy.transform.rotation * Vector2.up;
            GameObject shot = Factory.Instance.Shot_Factory.CreateShot(enemy.gameObject.transform, enemy.Rarity, enemy.ShotDamage, direction, 3, "Enemy");
            shot.transform.position = enemy.transform.position;
        }
    }
    public void ShootOverTime(Enemy enemy) { }
}
