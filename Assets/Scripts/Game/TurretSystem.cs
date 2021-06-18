using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSystem : MonoBehaviour
{
    private List<Turret> m_allTurrets;


    private void Start()
    {
        m_allTurrets = new List<Turret>();
    }

    public void Initialise()
    {
        AddTurret(Factory.Instance.Turret_Factory.CreateTurret(Rarity.GREY));
    }

    public void AddTurret(Turret turret)
    {
        bool replaced = false;
        for (int i = 0; i < m_allTurrets.Count && replaced == false; i++)
        {
            switch ( (int)turret.Rarity > (int)m_allTurrets[i].Rarity)
            {
                case true:
                    m_allTurrets[i] = turret;
                    replaced = true;
                    break;
            }
        }
        if(!replaced)
        {
            m_allTurrets.Add(turret);
        }

        ResetAllTurretsOffsets();
    }

    public void ResetAllTurretsOffsets()
    {
        float spacing = (0.16f * m_allTurrets.Count) / m_allTurrets.Count;
        float totalDistance = spacing * (m_allTurrets.Count - 1);

        for (int i = 0; i < m_allTurrets.Count; i++)
        {
            if (i == 0)
            {
                m_allTurrets[i].setOffset(-totalDistance / 2);
            }
            else
            {
                m_allTurrets[i].setOffset(-totalDistance / 2 + spacing * i);
            }
        }
    }

    public void Shoot()
    {
        foreach (Turret t in m_allTurrets)
        {
            t.Shoot();
        }
    }
    public void Update()
    {
        foreach (Turret t in m_allTurrets)
        {
            t.Update();
        }
    }
}
