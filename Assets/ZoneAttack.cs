using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAttack : MonoBehaviour
{
    private float m_lifeTime;
    private float m_damage;
    // Start is called before the first frame update
    void Awake()
    {
        m_lifeTime = 1.8f;
        m_damage = 1000;
    }

    public void Initialise(Vector3 position, float lifeTime, float damage)
    {
        this.transform.position = position;
        m_lifeTime = lifeTime;
        m_damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale *= 1 + Time.deltaTime;
        //Debug.Log("zoneAttack LifeTime: "+ m_lifeTime);
        m_lifeTime -= Time.deltaTime;
        if (m_lifeTime <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.GetComponent<Enemy>() == true)
        {
            case true:
                    collision.GetComponent<Enemy>().TakeDamage(m_damage);
                break;
        }
    }
}
