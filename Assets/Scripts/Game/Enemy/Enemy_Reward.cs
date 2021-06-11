using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Reward : MonoBehaviour
{
    [SerializeField]
    private int _scoreReward;
    [SerializeField]
    private float _lootChance;

    public void GetReward()
    {
        ScoreSystem.Instance.AddScore(_scoreReward);

        if (Random.Range(0, 100) <= _lootChance)
        {
            GameObject.FindObjectOfType<Factory>().Bonus_Factory.InstantiateBonus(this.transform.position);
        };
    }
}
