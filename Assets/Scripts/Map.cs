using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Map
{
    // Map size
    private static float _width = Camera.main.orthographicSize;
    private static float _height = Camera.main.orthographicSize * 2;

    // Player's spawn point
    private static Vector2 _playerSpawnPoint = new Vector2(0, -3); public static Vector2 PlayerSpawnPoint { get => _playerSpawnPoint; }

    // Enemy's spawn points
    private static int _spawnDensity = 6; public static int SpawnDensity { get => _spawnDensity; }

    private static Vector2 _firstSpawnPoint = new Vector2(-_width / 2 , _height / 2 + .5f);
    private static Vector2 _lastSpawnPoint = new Vector2(_width / 2 , _height / 2 + .5f);

    public static Vector2 SpawnIndexToPosition(int index)
    {
        Vector2 ratio = (_lastSpawnPoint - _firstSpawnPoint) / (_spawnDensity -1);

        if (index >= 0 && index < _spawnDensity) return _firstSpawnPoint + ratio * index;
        else { Debug.LogWarning("Spawn's index is out of range !"); return Vector2.zero; }
    }

    // Enemy's check Points
    private static int _checkPointDensityWidth = 10; public static int CheckPointDensityWidth { get => _checkPointDensityWidth; }
    private static int _checkPointDensityHeight = 15; public static int CheckPointDensityHeight { get => _checkPointDensityHeight; }

    private static Vector2 _firstCheckPoint = new Vector2(-_width / 2 + .5f, _height / 2 - 1.5f);
    private static Vector2 _lastCheckPoint = new Vector2(_width / 2 - .5f, -_height / 2 + .5f);
    public static int CheckPointDensity() { return _checkPointDensityWidth * _checkPointDensityHeight; }
    public static Vector2 CheckPointIndexToPosition(int index)
    {
        float ratioWidth = Mathf.Abs(_lastCheckPoint.x - _firstCheckPoint.x) / (_checkPointDensityWidth - 1);
        float ratioHeight = Mathf.Abs(_lastCheckPoint.y - _firstCheckPoint.y) / (_checkPointDensityHeight - 1);

        if(index >= 0 && index < _checkPointDensityWidth * _checkPointDensityHeight)
        {
            return _firstCheckPoint + new Vector2(index % _checkPointDensityWidth * ratioWidth, index / _checkPointDensityWidth * -ratioHeight);
        }
        else { Debug.LogWarning("CheckPoint's index is out of range !"); return Vector2.zero; }
    }
    public static bool IsOnScreen(Vector2 position)
    {
        return 
            position.x >= -_width / 2 &&
            position.x <= _width / 2 &&
            position.y >= -_height / 2 &&
            position.y <= _height / 2;
    }

    public static Vector3 RandomAround(Vector3 position, float radius)
    {
        float x = Random.Range(-radius, radius);
        float y = Random.Range(-radius, radius);
        return position + Vector3.right * x + Vector3.up * y;
    }
}

 