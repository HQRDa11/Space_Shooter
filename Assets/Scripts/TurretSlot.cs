using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlot : MonoBehaviour
{

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
                m_turret.SlotTransform = this.gameObject.transform;
                isFree = false;
                return true;

            case false:
                switch ((int)turret.Rarity > (int)m_turret.Rarity)
                {

                    case true:
                        m_turret = turret;
                        m_turret.SlotTransform = this.gameObject.transform;
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
