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
    private Player _player;
    private Vector3 _velocity;
    public float HealthRatio { get { return _health / _maxHealth; } }

    private GameObject _explosionAnim;

    public void Start()
    {
        _player = GameObject.Find("Player").gameObject.GetComponent<Player>();
        _explosionAnim = Resources.Load<GameObject>("Prefabs/Explosion");
        _velocity = Vector3.one;
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
        this.gameObject.transform.localScale *= 0.5f;
        _isPlayerShip = false;
        _AllyId = AllyId;
        _maxHealth = maxHealth;
        _health = _maxHealth;
        this._healtBar = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>().HealthBars[AllyId+1];
        this.gameObject.transform.SetParent(GameObject.Find("InGameObjects").transform);
        Update_HealthBar();
    }
    public void Update()
    {
        if(_isPlayerShip == false )
        {
            gameObject.transform.position = Vector3.SmoothDamp(this.gameObject.transform.position, _player.GetRelativeAllyPosition(_AllyId),ref _velocity,0.18f+(0.04f*_AllyId));
        }

        if (_health <= 0)
        {
            switch (_isPlayerShip)
            {
                case true:
                    Debug.LogWarning("GameOver");
                    GameObject.Find("Game").GetComponent<Game>().OnGameOver();
                    break;
                case false:
                    OnAllyDestruction();
                    break;
            }

        }
        if (Input.GetKey(KeyCode.K))
        {
            TakeDamage(100); Debug.Log("Key K has been Pressed");
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
        //Debug.Log(_health + "/" + _maxHealth);
        //Debug.Log(_healtBar.name);
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
