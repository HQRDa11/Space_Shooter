using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private static WaveSystem _instance; public static WaveSystem Instance { get => _instance;}

    private const int BOSS_WAVE_FREQUENCY = 10;
    private const int NUMBER_OF_WAVES_BY_DIFFICULTY = 10;
    private int _indexOfDifficulty;

    private List<Wave> _allWaves;
    private Wave _currentWave;
    private int _currentWaveIndex; public int CurrentWaveIndex { get => _currentWaveIndex; }

    private void Awake()
    {
        _instance = this;
        _indexOfDifficulty = 1;

        _allWaves = new List<Wave>();
        _allWaves.Add(Library.WaveList.RandomWave(_indexOfDifficulty));

        _currentWave = _allWaves[0];
        _currentWaveIndex = 1;
    }
    void Update()
    {
        if (_currentWave != null) _currentWave.Update();
    }
    public void NextWave()
    {
        _currentWaveIndex++;
        WaveDisplay.Instance.PulseEffect();

        if (_currentWaveIndex % BOSS_WAVE_FREQUENCY > 0) _currentWave = Library.WaveList.RandomWave(_indexOfDifficulty);
        else _currentWave = Library.WaveList.Boss(_currentWaveIndex / BOSS_WAVE_FREQUENCY % Library.EnemyList.NUMBER_OF_BOSS + 1);

        int random = Random.Range(0, 10);
        switch(random > 8)
        {
            case true:
                Debug.LogWarning("NEW DEPOSIT");
                int index = Random.Range(1, 5);
                Factory.Instance.General_Factory.Create_Deposit(200 * _currentWaveIndex, 3, Map.SpawnIndexToPosition(index));
                break;
        }
        if (_currentWaveIndex % NUMBER_OF_WAVES_BY_DIFFICULTY == 0)
        {
            SetDifficulty(_indexOfDifficulty + _currentWaveIndex / NUMBER_OF_WAVES_BY_DIFFICULTY);
        }
    }
    public void SetDifficulty(int difficulty)
    {
        _indexOfDifficulty = difficulty;
        Debug.Log("Difficulty is now " + (Diffulty)difficulty);
    }
}
