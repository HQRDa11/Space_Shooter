using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    public void DestroyFromHit()
    {
        ComboSystem.Instance.Addcombo();
        GetComponent<Enemy_Reward>().GetReward();
        Destroy(gameObject);
    }

    public void DestroyFromDeadzone()
    {
        ComboSystem.Instance.ResetCombo();
        Destroy(gameObject);
    }
}
