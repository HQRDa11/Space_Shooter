using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon_RandomShot : Enemy_Behaviours.Weapon
{
    public void Shoot(Enemy enemy)
    {
        if (Random.Range(0, 100) < enemy.ShotChance)
        {
            GameObject shot = Factory.Instance.Shot_Factory.CreateShot(Rarity.WHITE, enemy.transform.rotation * Vector2.up, 3f, "Enemy");
            shot.transform.position = enemy.transform.position;
        }
    }
}
