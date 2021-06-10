using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private static ScoreSystem _instance; public static ScoreSystem Instance { get => _instance; }
    private float _currentScore; public float CurrentScore { get => _currentScore; }

    private void Awake()
    {
        _instance = this;
    }
    public void AddScore(int score)
    {
        _currentScore += ComboSystem.Instance.Multiplier(score);
    }
}
