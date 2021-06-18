using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

        ReorganiseTurrets();
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

    public void ReorganiseTurrets()
    {


        List<Turret> orderedList = new List<Turret>();

        while (m_allTurrets.Count > 0)
        {
            orderedList.Add(MinRarity());
            m_allTurrets.Remove(MinRarity());
        }

        Turret[] arrayToReturn = new Turret[orderedList.Count];

        for (int i = 0; i < orderedList.Count; i++)
        {
            if (i == 0) arrayToReturn[0] = orderedList[0];

            else
            {
                if (i % 2 == 0) arrayToReturn[0 + i / 2] = orderedList[i];
                else arrayToReturn[arrayToReturn.Length - 1 - i / 2] = orderedList[i];
            }
        }
        m_allTurrets = arrayToReturn.ToList();
    }

    private Turret MinRarity()
    {
        Turret lowest = m_allTurrets[0];
        foreach (Turret t in m_allTurrets)
        {
            if ( (int)t.Rarity <= (int)lowest.Rarity)
            {
                lowest = t;
            }
        }
        return lowest;
    }
}
