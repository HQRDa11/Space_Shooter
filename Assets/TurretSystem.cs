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

    public void Initialise( int nbOfTurrets)
    {
        float posX = -gameObject.transform.localScale.x / 2;
        float margin = gameObject.transform.localScale.x * 1.5f / nbOfTurrets;
        for (int i = 0; i < nbOfTurrets; i++)
        {
            float newXOffset = posX + (i * margin);
            Turret newTurret = new Turret(this.gameObject, newXOffset );
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
