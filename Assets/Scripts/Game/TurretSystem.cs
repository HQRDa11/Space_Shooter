using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurretSystem : MonoBehaviour
{
    private List<TurretSlot> m_allTurretSlots;
    private void Awake()
    {
        m_allTurretSlots = new List<TurretSlot>();
        m_allTurretSlots = GetComponentsInChildren<TurretSlot>().ToList<TurretSlot>();

    }
    private void Start()
    {
        //Debug.Log("nbOfTurretSlots: " + m_allTurretSlots.Count);
        AddTurret(Factory.Instance.Turret_Factory.CreateTurret(Rarity.GREY));
    }
    public void SetTurretSlotDamage(double damage)
    {
        for (int i = 0; i<m_allTurretSlots.Count;i++)
        {
            m_allTurretSlots[i].Damage = damage;
            Debug.Log("finaltestdamage=" + damage);
        }
    }

    public bool AddTurret(Turret turret)
    {
        bool replaced = false;
        for (int i=0; i<m_allTurretSlots.Count && replaced == false; i++)
        {
            replaced = m_allTurretSlots[i].SetTurret(turret);
        }
        return replaced;
    }

    //public void ResetAllTurretsOffsets()
    //{
    //    float spacing = (0.16f * m_allTurrets.Count) / m_allTurrets.Count;
    //    float totalDistance = spacing * (m_allTurrets.Count - 1);

    //    for (int i = 0; i < m_allTurrets.Count; i++)
    //    {
    //        if (i == 0)
    //        {
    //            m_allTurrets[i].setOffset(-totalDistance / 2);
    //        }
    //        else
    //        {
    //            m_allTurrets[i].setOffset(-totalDistance / 2 + spacing * i);
    //        }
    //    }
    //}

    public void Shoot()
    {
        foreach (TurretSlot slot in m_allTurretSlots)
        {
            slot.Shoot();
        }
    }

    //public void ReorganiseTurrets()
    //{


    //    List<Turret> orderedList = new List<Turret>();

    //    while (m_allTurrets.Count > 0)
    //    {
    //        orderedList.Add(MinRarity());
    //        m_allTurrets.Remove(MinRarity());
    //    }

    //    Turret[] arrayToReturn = new Turret[orderedList.Count];

    //    for (int i = 0; i < orderedList.Count; i++)
    //    {
    //        if (i == 0) arrayToReturn[0] = orderedList[0];

    //        else
    //        {
    //            if (i % 2 == 0) arrayToReturn[0 + i / 2] = orderedList[i];
    //            else arrayToReturn[arrayToReturn.Length - 1 - i / 2] = orderedList[i];
    //        }
    //    }
    //    m_allTurrets = arrayToReturn.ToList();
    //}

    //private Turret MinRarity()
    //{
    //    Turret lowest = m_allTurrets[0];
    //    foreach (Turret t in m_allTurrets)
    //    {
    //        if ( (int)t.Rarity <= (int)lowest.Rarity)
    //        {
    //            lowest = t;
    //        }
    //    }
    //    return lowest;
    //}
}
