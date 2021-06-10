using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField]
    private float _health;

    private void Update()
    {
        if (_health <= 0) GetComponent<Enemy_Manager>().DestroyFromHit();
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
    }
}
