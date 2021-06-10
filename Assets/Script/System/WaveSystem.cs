using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private static WaveSystem _instance; public static WaveSystem Instance { get => _instance;}

    private List<Wave> _allWaves;
    private Wave _currentWave;

    private void Awake()
    {
        _instance = this;

        _allWaves = new List<Wave>();
        _allWaves.Add(new Wave01());
        _allWaves.Add(new Wave02());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _currentWave = _allWaves[0]; 
        }

        if (_currentWave != null) _currentWave.Update();
    }

    public void NextWave()
    {
        if(_allWaves.IndexOf(_currentWave) < _allWaves.Count - 1) _currentWave = _allWaves[_allWaves.IndexOf(_currentWave) + 1];
    }
}
