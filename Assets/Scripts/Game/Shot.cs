using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;

    private Vector2 _direction;

    // Start is called before the first frame update
    void Start()
    {
        _damage = 10;
    }

    public void Initialise(int damage, Vector2 direction, float speed)
    {
        _damage = damage ;
        _direction = direction;
        _speed = speed;
        transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(_direction.x, -_direction.y)) * 180 / Mathf.PI;
    }

    // Update is called once per frame
    void Update()
    {
       if (!Map.IsOnScreen(this.transform.position))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //this.transform.Translate( _direction * _speed * Time.deltaTime);
        this.transform.position += (Vector3)_direction * _speed * Time.deltaTime;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (gameObject.tag)
        {
            case "Player":
                if (collision.gameObject.tag == "Enemy")
                {
                    if (collision.GetComponent<Enemy_Health>())
                    {
                        collision.GetComponent<Enemy_Health>().TakeDamage(_damage);
                        GameObject.Destroy(this.gameObject);
                    }
                   
                }
                return;

            case "Enemy":
                if (collision.gameObject.tag == "PlayerShip")
                {

                    collision.GetComponent<Ship>().TakeDamage(_damage);
                    GameObject.Destroy(this.gameObject);
                }
                return;
            default:
                Debug.Log("Unkown Exception");
                break;
        }
    }
}
