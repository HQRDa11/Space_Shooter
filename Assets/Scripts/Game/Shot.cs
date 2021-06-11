using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private float _lifeTime;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;

    // Start is called before the first frame update
    void Start()
    {
        _lifeTime = 3;
        _speed = 16;
        _damage = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Update_LifeTime();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {        
        this.transform.Translate(Vector3.up * _speed * Time.deltaTime);       
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
            collision.GetComponent<Enemy_Health>().TakeDamage(_damage);
            GameObject.Destroy(this.gameObject);
        }
    }
}
