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
        ModifyNbOfTurret(1);
    }

    public void ModifyNbOfTurret(int modifier)
    {
        int totalTurret = m_allTurrets.Count + modifier;
        m_allTurrets.Clear();

        float posX = -gameObject.transform.localScale.x / 2;
        float margin = gameObject.transform.localScale.x * ( 1 + 0.1f * totalTurret) / totalTurret;
        for (int i = 0; i < totalTurret; i++)
        {
            float newXOffset = posX + (i * margin);
            Turret newTurret = new Turret(this.gameObject, newXOffset);
            m_allTurrets.Add(newTurret);
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
