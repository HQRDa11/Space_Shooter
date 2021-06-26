using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAttack : MonoBehaviour
{
    private float m_lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        m_lifeTime = 1.8f;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale *= 1 + Time.deltaTime;

        m_lifeTime -= Time.deltaTime;
        if (m_lifeTime <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.GetComponent<Enemy_Health>() == true )
        {
            case true:
            collision.GetComponent<Enemy_Health>().TakeDamage(1000);
            break;
        }
    }
}
