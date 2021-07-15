using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private float m_energy;
    public float Energy { get => m_energy; }
    private float m_maxEnergy;


    // Start is called before the first frame update
    void Start()
    {
        m_maxEnergy = 10;
        m_energy = m_maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_energy <=0)
        {
            case true:
                GameObject.Destroy(this.gameObject);
                return;
        }
    }

    public void RechargeFull()
    {
        m_energy = m_maxEnergy;
    }

    public void TakeDamage(float damage)
    {
        m_energy -= damage;
    }
}
