using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyBalance
{
    private static float _healthRatio = 1.1f;
    public static float HealthBalancing(float health)
    { 
        for (int i = 0; i < WaveSystem.Instance.CurrentWaveIndex-1; i++) health *= _healthRatio; /*Debug.Log("HEALTH" + health);*/ 
        return health;
    }

    private static float _lootChanceRatio = .9f;
    public static float LootChanceBalancing(float lootChance)
    {
        for (int i = 0; i < WaveSystem.Instance.CurrentWaveIndex -1; i++) lootChance *= _lootChanceRatio; 
        return lootChance; 
    }

    private static float _shotChanceRatio = 1.1f;
    public static float ShotChanceBalancing(float shotChance) 
    {
        for (int i = 0; i < WaveSystem.Instance.CurrentWaveIndex - 1; i++) shotChance *= _shotChanceRatio; 
        return shotChance;
    }
}
