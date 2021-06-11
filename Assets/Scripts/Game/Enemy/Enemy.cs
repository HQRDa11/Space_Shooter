using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public void Initialise(float level)
    {
        float health = 10 + level * 3;
        this.gameObject.GetComponent<Enemy_Health>().SetHealth(health, health);
    }

}
