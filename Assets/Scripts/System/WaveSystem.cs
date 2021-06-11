using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private static WaveSystem _instance; public static WaveSystem Instance { get => _instance;}

    private List<Wave> _allWaves;
    private Wave _currentWave;

    [SerializeField]
    private int _startAtWave;
    private int _currentWaveIndex; public int CurrentWaveIndex { get => _currentWaveIndex; }

    private void Awake()
    {
        _instance = this;

        _allWaves = new List<Wave>();
        _allWaves.Add(SetWaveOnDiffilculty(_startAtWave));

        _currentWave = _allWaves[0];
        _currentWaveIndex = _startAtWave;
    }
    void Update()
    {
        if (_currentWave != null) _currentWave.Update();
    }

    public void NextWave()
    {
        _currentWaveIndex++;
        WaveDisplay.Instance.PulseEffect();

        if(_currentWaveIndex % 5 > 0) _currentWave = SetWaveOnDiffilculty(_currentWaveIndex / 5 + 1);
        else _currentWave = SetWaveOnDiffilculty(_currentWaveIndex / 5 + 1); // <<< A REMPLACER
        // ELSE BossWave !!!

        //if(_allWaves.IndexOf(_currentWave) < _allWaves.Count - 1) _currentWave = _allWaves[_allWaves.IndexOf(_currentWave) + 1];
    }

    private Wave RandomWave()
    {
        int numberOfEnemy = Random.Range(5, 20); 
        int spawnPoint = Random.Range(0, Map.SpawnDensity - 1); 
        float spawnDelay = Random.Range(.1f, 1f); 
        int repeatTimes = Random.Range(0, 3); 
        float repeatFrenquency = Random.Range(3f, 5f); 
        int[] checkPoints = new int[Random.Range(5, 10)]; 
        for (int i = 0; i < checkPoints.Length; i++) checkPoints[i] = Random.Range(0, Map.CheckPointDensityWidth * Map.CheckPointDensityHeight - 1);
        bool mirror = true;

        return new Wave(numberOfEnemy, spawnPoint, spawnDelay, repeatTimes, repeatFrenquency, checkPoints, mirror);
    }

    private Wave SetWaveOnDiffilculty(int difficulty)
    {
        Debug.Log(difficulty);
        int numberOfEnemy = Random.Range(4, 8) * difficulty;
        int spawnPoint = Random.Range(0, Map.SpawnDensity - 1);
        float spawnDelay = Random.Range(.5f, 2f) / difficulty;
        int repeatTimes = Random.Range(0, 1) * difficulty;
        float repeatFrenquency = Random.Range(3f, 5f) / difficulty;
        int[] checkPoints = new int[Random.Range(3, 5) * difficulty];
        for (int i = 0; i < checkPoints.Length; i++) checkPoints[i] = Random.Range(0, Map.CheckPointDensityWidth * Map.CheckPointDensityHeight - 1);
        bool mirror = Random.Range(0, 100) <= 100 / difficulty ? false : true; 
        Debug.Log("Random " + (float)Random.Range(0, 100 / difficulty));
        Debug.Log("Chance " + (100 / difficulty));

        return new Wave(numberOfEnemy, spawnPoint, spawnDelay, repeatTimes, repeatFrenquency, checkPoints, mirror);
    }
}
