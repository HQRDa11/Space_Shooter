using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Ship : MonoBehaviour
{
    private int        m_allyId;

    private bool m_isPlayerShip;
    private Player     m_player;

    private float      m_health;
    private float   m_maxHealth;
    public  float HealthRatio { get { return m_health / m_maxHealth; } }
    
    private Vector3  m_velocity;
    private Image    m_healtBar;

    public Shield Shield;
    public bool HasDrone { get; set; }

    //next should be removre from here:
    private GameObject _explosionAnim;

    private StatBonuses m_statBonuses;
    private struct StatBonuses
    {
        public float ShieldEnergy;
        public StatBonuses(float shieldEnergy)
        {
            ShieldEnergy = shieldEnergy;
        }
    }
    public void Start()
    {
        m_player = GameObject.Find("Player").gameObject.GetComponent<Player>();
        _explosionAnim = Resources.Load<GameObject>("Prefabs/Explosion");
        m_velocity = Vector3.one;
        HasDrone = false;
    }

    public void InitialisePlayerShip( float maxHealth)
    {
        m_isPlayerShip = true;
        InitialiseBonuses_wProfileData();
        m_maxHealth = maxHealth;
        m_health = m_maxHealth;
        this.m_healtBar = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>().HealthBars[0];
        Update_HealthBar();
    }
    public void InitialiseAllyShip(int AllyId, float maxHealth)
    {
        this.gameObject.transform.localScale *= 0.5f;
        m_isPlayerShip = false;
        InitialiseBonuses_wProfileData();
        m_allyId = AllyId;
        m_maxHealth = maxHealth;
        m_health = m_maxHealth;
        this.m_healtBar = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>().HealthBars[AllyId+1];
        this.gameObject.transform.SetParent(GameObject.Find("InGameObjects").transform);
        Update_HealthBar();
    }
    private void InitialiseBonuses_wProfileData()
    {
        ModuleData[] moduleDatas;
        switch (m_isPlayerShip)
        {
            case true:
                moduleDatas = ProfileHandler.Instance.ActiveProfile.SquadronData.AllMembers[0].Ship.AllModules;
                break;
            case false:
                moduleDatas = ProfileHandler.Instance.ActiveProfile.SquadronData.AllMembers[m_allyId + 1].Ship.AllModules;
                break;
        }
        float shieldEnergy = 0;

        foreach (ModuleData data in moduleDatas)
        {
            switch (data.Type == ModuleType.SHIELD)
            {
                case true:
                    shieldEnergy += Factory.Instance.ModuleStat_Factory.Get_Stat(data, ModuleStatType.ENERGY, true);
                    //Debug.LogWarning("repairdroneEnergyBonus = " + shieldEnergy);
                    break;
            }
        }
        m_statBonuses = new StatBonuses(shieldEnergy);
    }

    
    public void Update()
    {
        if(m_isPlayerShip == false )
        {
            gameObject.transform.position = Vector3.SmoothDamp(this.gameObject.transform.position, m_player.GetRelativeAllyPosition(m_allyId),ref m_velocity,0.18f+(0.04f*m_allyId));
        }

        if (m_health <= 0)
        {
            switch (m_isPlayerShip)
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
            TakeDamage(100); Debug.Log("Damage taken: 100 - Key K has been Pressed");
        }
    }

    public void SetHealth(float max, float current)
    {
        m_maxHealth = max;
        m_health = current;
        Update_HealthBar();
    }

    public void TakeDamage(float damage)
    {
        m_health -= damage;
        Update_HealthBar();
    }
    public void ModifyHealth(float modifier)
    {
        m_health += modifier;
        Update_HealthBar();
    }
    public void Update_HealthBar()
    {
        //Debug.Log(_health + "/" + _maxHealth);
        //Debug.Log(_healtBar.name);
        m_healtBar.fillAmount = m_health / m_maxHealth;
    }

    public void OnAllyDestruction()
    {
        GameObject.Find("Player").GetComponent<Player>().AllAllies[m_allyId] = null;
        GameObject.Destroy(this.gameObject);

        GameObject explosion = GameObject.Instantiate(_explosionAnim);
        explosion.transform.position = this.gameObject.transform.position;
    }

    public void NewShield()
    {
        Shield = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Shield"),this.gameObject.transform).GetComponent<Shield>();
        Shield.Initialise(m_statBonuses.ShieldEnergy);
        //Debug.LogWarning("Shield energy Value = " + Shield.Energy);
    }


}
