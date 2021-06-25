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
    private bool _isPlayerShip;
    private int  _AllyId;
    public float HealthRatio { get { return _health / _maxHealth; } }

    private GameObject _explosionAnim;

    public void Start()
    {
        _explosionAnim = Resources.Load<GameObject>("Prefabs/Explosion");
    }

    public void InitialisePlayerShip( float maxHealth)
    {
        _isPlayerShip = true;
        _maxHealth = maxHealth;
        _health = _maxHealth;
        this._healtBar = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>().HealthBars[0];
        Update_HealthBar();
    }
    public void InitialiseAllyShip(int AllyId, float maxHealth)
    {
        _isPlayerShip = false;
        _AllyId = AllyId;
        _maxHealth = maxHealth;
        _health = _maxHealth;
        this._healtBar = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>().HealthBars[AllyId+1];
        Update_HealthBar();
    }
    public void Update()
    {
        if (_health <= 0)
        {
            switch (_isPlayerShip)
            {
                case true:
                    Debug.LogWarning("GameOver");
                    break;
                case false:
                    OnAllyDestruction();
                    break;
            }

        }
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
        Debug.Log(_health + "/" + _maxHealth);
        Debug.Log(_healtBar.name);
        _healtBar.fillAmount = _health / _maxHealth;
    }

    public void OnAllyDestruction()
    {
        GameObject.Find("Player").GetComponent<Player>().AllAllies[_AllyId] = null;
        GameObject.Destroy(this.gameObject);

        GameObject explosion = GameObject.Instantiate(_explosionAnim);
        explosion.transform.position = this.gameObject.transform.position;
    }
}
