using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Ship : MonoBehaviour
{
    private float _health;
    private float _maxHealth;
    private Image _healtBar;

    public float HealthRatio { get { return _health / _maxHealth; } }

    public void Start()
    {
        
    }

    public void Initialise(int id, float maxHealth)
    {
        _maxHealth = maxHealth;
        _health = _maxHealth;
        this._healtBar = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>().HealthBars[id];
        Update_HealthBar();
    }
    public void Update()
    {
        if (_health <= 0) return;// => OnShipDestruction();
    }

    public void SetHealth(float max, float current)
    {
        _maxHealth = max;
        _health = current;
        Update_HealthBar();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        Update_HealthBar();
    }
    public void ModifyHealth(float modifier)
    {
        _health += modifier;
        Update_HealthBar();
    }
    public void Update_HealthBar()
    {
        //Debug.Log(_health + "/" + _maxHealth);
        //Debug.Log(_healtBar.name);
        _healtBar.fillAmount = _health / _maxHealth;
    }
}
