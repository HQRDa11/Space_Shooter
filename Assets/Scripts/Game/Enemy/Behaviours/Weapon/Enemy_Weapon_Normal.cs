using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon_Normal : Enemy_Behaviours.Weapon
{
    public void Shoot(Enemy enemy)
    {
        GameObject shot = Factory.Instance.Shot_Factory.CreateShot(Factory.Instance.InGameObjectsList, Rarity.WHITE, enemy.transform.rotation * Vector2.up, 3f, "Enemy");
        shot.transform.position = enemy.transform.position;
    }
    public void ShootOverTime(Enemy enemy) { }

}
