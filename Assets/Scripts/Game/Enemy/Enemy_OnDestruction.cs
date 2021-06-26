using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_OnDestruction : MonoBehaviour
{
    private GameObject _explosionAnim;

    public void Start()
    {
        _explosionAnim = Resources.Load<GameObject>("Prefabs/Explosion");
    }
    public void DestroyFromHit()
    {
        GetComponent<Enemy_Reward>().GetReward();
        ComboSystem.Instance.AddCombo();

        GameObject explosion = GameObject.Instantiate(_explosionAnim);
        explosion.transform.position = this.gameObject.transform.position;

        Destroy(gameObject);
    }

    public void DestroyFromDeadzone()
    {
        ComboSystem.Instance.ResetCombo();
        Destroy(gameObject);
    }
}
