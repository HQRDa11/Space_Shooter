using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBonus : MonoBehaviour
{
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Try_Destruction();
    }

    private void Move()
    {
        this.transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
    private void Try_Destruction()
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
                collision.gameObject.GetComponent<Player>().OnRepairDroneBonus();
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
