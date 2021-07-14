using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentBonus : MonoBehaviour
{
    private float _speed;
    private Rarity _rarity;

    public Rarity Rarity { get => _rarity; set { _rarity = value; } }

    // Start is called before the first frame update
    void Start()
    {
        _speed = 2;
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
            this.transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
    }
    private void Update_LifeTime()
    {
        if (!Map.IsOnScreen(this.transform.position))
        {
            GameObject.Destroy(this.gameObject);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Player>())
            {
                //Debug.Log("bonus rarity: " + _rarity);
                collision.gameObject.GetComponent<Player>().OnComponentBonus(_rarity);
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
