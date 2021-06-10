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

    private static Vector2 _firstSpawnPoint = new Vector2(-_width / 2 - .5f, _height / 2 + .5f);
    private static Vector2 _lastSpawnPoint = new Vector2(_width / 2 + .5f, _height / 2 + .5f);

    public static Vector2 SpawnIndexToPosition(int index)
    {
        Vector2 ratio = (_lastSpawnPoint - _firstSpawnPoint) / (_spawnDensity -1);

        if (index >= 0 && index < _spawnDensity) return _firstSpawnPoint + ratio * index;
        else { Debug.LogWarning("Spawn's index is out of range !"); return Vector2.zero; }
    }

    // Enemy's check Points
    private static int _checkPointDensity = 6; public static int CheckPointDensity { get => _checkPointDensity; }

    private static Vector2 _firstCheckPoint = new Vector2(-_width / 2 - .5f, _height / 2 - .5f);
    private static Vector2 _lastCheckPoint = new Vector2(_width / 2 + .5f, -_height / 2 - .5f);

    public static Vector2 CheckPointIndexToPosition(int index)
    {
        float ratioWidth = Mathf.Abs(_lastCheckPoint.x - _firstCheckPoint.x) / (_checkPointDensity - 1);
        float ratioHeight = Mathf.Abs(_lastCheckPoint.y - _firstCheckPoint.y) / (_checkPointDensity - 1);

        if(index >= 0 && index < Mathf.Pow(_checkPointDensity, 2))
        {
            // Retourne le checkPoint correspondant à l'index <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return _firstCheckPoint + new Vector2(index % _checkPointDensity * ratioWidth, index / _checkPointDensity * -ratioHeight);
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
}

