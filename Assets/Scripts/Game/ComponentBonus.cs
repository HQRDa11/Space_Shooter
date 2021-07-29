using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentBonus : MonoBehaviour
{
    private float _speed;
    private Rarity _rarity;
    private float _timerBefore_isTargetingPlayer;

    private Player _player;

    public Rarity Rarity { get => _rarity; set { _rarity = value; } }

    // Start is called before the first frame update
    void Start()
    {
        _speed = 2;
        _timerBefore_isTargetingPlayer = 1;

        _player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Update_LifeTime();
    }

    private void Move()
    {
        switch (_timerBefore_isTargetingPlayer<0)
        {
            case true:
                this.transform.position = Vector3.MoveTowards(this.transform.position, _player.transform.position, Time.deltaTime * 2);
                break;
            case false:
                this.transform.Translate(Vector3.down * _speed * Time.deltaTime);
                break;
        }
    }
    private void Update_LifeTime()
    {
        _timerBefore_isTargetingPlayer -= Time.deltaTime;
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
