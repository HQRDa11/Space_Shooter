using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        _lifeTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _lifeTime -= Time.deltaTime;
        {
            if (_lifeTime <= 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
