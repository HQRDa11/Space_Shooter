using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy_Health : MonoBehaviour
{
    private float _health;
    [SerializeField]
    private float _maxHealth;

    private void Start()
    {
        _maxHealth = EnemyBalance.HealthBalancing(_maxHealth);
        _health = _maxHealth;
    }

    private void Update()
    {
        if (_health <= 0) GetComponent<Enemy_Manager>().DestroyFromHit();
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        this.gameObject.transform.GetComponentInChildren<Canvas>().GetComponentInChildren<Image>().fillAmount = _health / _maxHealth; 
    }
}
