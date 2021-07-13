using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon_MultiShot_Circle : Enemy_Behaviours.Weapon
{
    private bool _isFiring = false;
    private int _numberOfShot = 10;
    private int _shotIndex = 0;
    public void Shoot(Enemy enemy)
    {
        if (_isFiring == false) _isFiring = true;

        if (_isFiring == true)
        {
            float angle = (enemy.transform.eulerAngles.z + 360 / (_numberOfShot + 1) *_shotIndex ) % 360;
            float rad = Mathf.Deg2Rad * angle;
            
            Vector2 direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)); 

            GameObject shot = Factory.Instance.Shot_Factory.CreateShot(Factory.Instance.InGameObjectsList, Rarity.WHITE, direction, 3f, "Enemy");
            shot.transform.position = enemy.transform.position;

            if (_shotIndex < _numberOfShot)
            {
                _shotIndex++;
                Shoot(enemy);
            }
            else
            {
                _isFiring = false;
                _shotIndex = 0;
            }
        }
    }
    public void ShootOverTime(Enemy enemy) { }

}
