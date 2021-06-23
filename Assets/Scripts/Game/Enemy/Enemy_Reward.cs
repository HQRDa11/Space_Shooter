using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Reward : MonoBehaviour
{
    [SerializeField]
    private int _scoreReward;
    [SerializeField]
    private float _lootChance;

    private void Start()
    {
        _lootChance = EnemyBalance.LootChanceBalancing(_lootChance);
    }
    public void GetReward()
    {
        ScoreSystem.Instance.AddScore(_scoreReward);

        if (Random.Range(0, 100) <= _lootChance)
        {
            Factory.Instance.Bonus_Factory.Instantiate_RandomBonus(this.transform.position);
        };
    }
}
