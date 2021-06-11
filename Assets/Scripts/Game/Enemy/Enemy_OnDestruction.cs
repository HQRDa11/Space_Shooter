using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_OnDestruction : MonoBehaviour
{
    public void DestroyFromHit()
    {
        GetComponent<Enemy_Reward>().GetReward();
        ComboSystem.Instance.Addcombo();
        Destroy(gameObject);
    }

    public void DestroyFromDeadzone()
    {
        ComboSystem.Instance.ResetCombo();
        Destroy(gameObject);
    }
}
