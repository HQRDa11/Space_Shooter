using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlot : MonoBehaviour
{
    private double m_damage;
    public double Damage { get=>m_damage; set { m_damage = value; } }
    private Turret m_turret;
    public bool isFree { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        isFree = true;
    }

    public bool SetTurret(Turret turret)
    {
        if (m_turret == null) isFree = true;
        switch (isFree)
        {
            case true:
                m_turret = turret;
                m_turret.Slot = this;
                this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Factory.Instance.Material_Factory.GetMaterial(m_turret.Rarity).color;
                isFree = false;
                return true;

            case false:
                switch ((int)turret.Rarity > (int)m_turret.Rarity)
                {

                    case true:
                        Rarity replaced = m_turret.Rarity;
                        m_turret = turret;
                        m_turret.Slot = this;
                        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Factory.Instance.Material_Factory.GetMaterial(m_turret.Rarity).color;
                        GameObject.Find("Player").GetComponent<Player>().OnTurretBonus(replaced);
                        Debug.LogWarning("here ok");
                        return true;

                    case false:
                    return false;
                }
        }
    }
    public void Shoot()
    {
        switch (isFree)
        {
            case false:
                m_turret.Shoot();
                return;
        }
    }
    public void Update()
    {
        switch (isFree)
        {
            case false:
                m_turret.Update();
                return;
        }
    }
}
