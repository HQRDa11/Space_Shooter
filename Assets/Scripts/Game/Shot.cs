using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    [SerializeField]
    private float _speed;
    [SerializeField]
    private double _damage;

    private Vector2 _direction;


    public void Initialise(double damage, Vector2 direction, float speed)
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
                switch (collision.gameObject.tag)
                {
                    case "Enemy":
                        if (collision.GetComponent<Enemy>())
                        {
                            collision.GetComponent<Enemy>().TakeDamage(_damage);
                            GameObject.Destroy(this.gameObject);
                        }
                        return;
                    case "Damageable":
                        if (collision.GetComponent<Deposit>())
                        {
                            collision.GetComponent<Deposit>().TakeDamage(_damage);
                            GameObject.Destroy(this.gameObject);
                        }
                        return;
                }
                return;

            case "Enemy":

                switch (collision.gameObject.tag)
                {
                    case "Enemy":
                        return;

                    case "Player":
                        return;

                    case "Bonus":
                        return;

                    case "PlayerShip":
                        collision.GetComponent<Ship>().TakeDamage(_damage);
                        GameObject.Destroy(this.gameObject);
                        return;

                    case "PlayerShield":
                        collision.GetComponent<Shield>().TakeDamage(_damage);
                        GameObject.Destroy(this.gameObject);
                        return;

                    default:
                        Debug.Log("Unkown collision Exception / " + gameObject.tag + " shot - " + collision.gameObject.tag + " called:"+ collision.gameObject.name + " at: " + collision.transform.position );
                        break;
                }

                return;
            default:
                Debug.Log("Unkown Exception");
                break;
        }
    }
}
