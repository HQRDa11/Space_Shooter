using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private float _lifeTime;
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _lifeTime = 8;
        _speed = 12;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Update_LifeTime();
    }

    private void Move()
    {
        {
            this.transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
    }
    private void Update_LifeTime()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy_Health>().TakeDamage(10);
            GameObject.Destroy(this.gameObject);
        }
    }
}
