using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private static ComboSystem _instance; public static ComboSystem Instance { get => _instance; }

    private int _currentCombo;
    private void Awake()
    {
        _instance = this;
    }
    public void Addcombo() { _currentCombo++; }
    public void ResetCombo() { _currentCombo = 0; }
    public int Multiplier(int score) { return score * _currentCombo; }
}