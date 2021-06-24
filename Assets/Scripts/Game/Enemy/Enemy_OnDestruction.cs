using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_OnDestruction : MonoBehaviour
{
    public void DestroyFromHit()
    {
        GetComponent<Enemy_Reward>().GetReward();
        ComboSystem.Instance.AddCombo();

        GameObject explosion = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"));
        explosion.transform.position = this.gameObject.transform.position;


        Destroy(gameObject);
    }

    public void DestroyFromDeadzone()
    {
        ComboSystem.Instance.ResetCombo();
        Destroy(gameObject);
    }
}
