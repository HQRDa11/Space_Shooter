using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private float m_energy;
    public float Energy { get => m_energy; }
    private float m_maxEnergy;
    private int m_baseEnergy;
    private GameObject _particules;

    [SerializeField]
    private float rotationSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        m_baseEnergy = 30;
        m_maxEnergy = m_baseEnergy;
        m_energy = m_maxEnergy;
        _particules = gameObject.GetComponentInChildren<ParticleSystem>().gameObject;
    }

    public void Initialise(float energyModuleModifier)
    {
        m_maxEnergy = m_baseEnergy + energyModuleModifier;
        m_energy = m_maxEnergy;
    }
    // Update is called once per frame
    void Update()
    {
        _particules.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
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

    public void TakeDamage(double damage)
    {
        m_energy -= (float)damage;
    }
}
