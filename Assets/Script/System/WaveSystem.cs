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
        _allWaves.Add(RandomWave());
        _allWaves.Add(RandomWave());
        _allWaves.Add(RandomWave());
        _allWaves.Add(new Wave(5, 2, .5f, 2, 2f, new int[6] { 0, 11, 12, 23, 24, 35 }));
        _allWaves.Add(new Wave(10, 1, .5f, 1, 3f, new int[6] { 1, 19, 4, 1, 22, 30 }));
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

    private Wave RandomWave()
    {
        int numberOfEnemy = Random.Range(5, 20); Debug.Log("numberOfEnemy " + numberOfEnemy);
        int spawnPoint = Random.Range(0, Map.SpawnDensity - 1); Debug.Log("spawnPoint " + spawnPoint);
        float spawnDelay = Random.Range(.1f, 1f); Debug.Log("spawnDelay " + spawnDelay);
        int repeatTimes = Random.Range(0, 3); Debug.Log("repeatTimes " + repeatTimes);
        float repeatFrenquency = Random.Range(3f, 5f); Debug.Log("repeatFrenquency " + repeatFrenquency);
        int[] checkPoints = new int[Random.Range(5, 10)]; Debug.Log("checkPoints lenght" + checkPoints.Length);
        for (int i = 0; i < checkPoints.Length; i++) checkPoints[i] = Random.Range(0, (int)Mathf.Pow(Map.CheckPointDensity, 2) - 1);
        Debug.Log("");
        Debug.Log("");
        return new Wave(numberOfEnemy, spawnPoint, spawnDelay, repeatTimes, repeatFrenquency, checkPoints);
    }
}
