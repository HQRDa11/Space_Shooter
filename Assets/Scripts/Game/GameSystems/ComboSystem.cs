using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private static ComboSystem _instance; public static ComboSystem Instance { get => _instance; }

    [SerializeField]
    private float _resetDelay;
    private int _currentCombo; public int CurrentCombo { get => _currentCombo; }

    private float _clock;

    private void Awake()
    {
        _instance = this;
        _resetDelay = 2.1f;
        _clock = 0;
    }

    private void Update()
    {
        _clock += Time.deltaTime;
        if (_clock > _resetDelay) ResetCombo();
    }
    public void AddCombo() { _currentCombo++; ComboDisplay.Instance.PulseEffect(); _clock = 0; }
    public void ResetCombo() { _currentCombo = 0; }
    public float Multiplier(float score) { return score * (_currentCombo + 1); }
}
