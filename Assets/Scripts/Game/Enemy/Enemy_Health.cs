using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy_Health : MonoBehaviour
{
    private float _health;
    [SerializeField]
    private float _maxHealth;

    public void SetHealth( float max, float current)
    {
        Debug.Log(current);
        _maxHealth = max;
        _health = current;
    }

    private void Start()
    {
        _maxHealth = EnemyBalance.HealthBalancing(_maxHealth);
        _health = _maxHealth;
    }

    private void Update()
    {
        if (_health <= 0) GetComponent<Enemy_OnDestruction>().DestroyFromHit();
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        this.gameObject.transform.GetComponentInChildren<Canvas>().GetComponentInChildren<Image>().fillAmount = _health / _maxHealth; 
    }
}
