using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private static WaveSystem _instance; public static WaveSystem Instance { get => _instance;}

    private List<Wave> _allWaves;
    private Wave _currentWave;
    private int _currentWaveIndex;

    private void Awake()
    {
        _instance = this;

        _allWaves = new List<Wave>();
        _allWaves.Add(SetWaveOnDiffilculty(1));
        //_allWaves.Add(SetWaveOnDiffilculty(2));
        //_allWaves.Add(SetWaveOnDiffilculty(3));

        //_allWaves.Add(new Wave(5, 2, .5f, 2, 2f, new int[6] { 0, 11, 12, 23, 24, 35 }, true));
        //_allWaves.Add(new Wave(10, 1, .5f, 1, 3f, new int[6] { 1, 19, 4, 1, 22, 30 }, false));

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

        //Debug.Log("numberOfEnemy " + numberOfEnemy);
        //Debug.Log("spawnPoint " + spawnPoint);
        //Debug.Log("spawnDelay " + spawnDelay);
        //Debug.Log("repeatTimes " + repeatTimes);
        //Debug.Log("repeatFrenquency " + repeatFrenquency);
        //Debug.Log("checkPoints lenght" + checkPoints.Length);
        //Debug.Log("");

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
        bool mirror = (float)Random.Range(0, 100 / difficulty != 0 ? difficulty : 1) <= (float)100 / (float)difficulty ? false : true; Debug.Log("Mirror " + (float)Random.Range(0, 100 / difficulty));

        return new Wave(numberOfEnemy, spawnPoint, spawnDelay, repeatTimes, repeatFrenquency, checkPoints, mirror);
    }
}
