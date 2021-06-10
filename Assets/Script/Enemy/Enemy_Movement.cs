using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private List<Vector2> _allCheckPoints; public List<Vector2> AllCheckPoints { set => _allCheckPoints = value; }
    private int _checkPointIndex;
    private Vector2 _direction;
    private bool _isAtLastCheckPoint;
    private int _number; public int Number { set => _number = value; }

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _smoothing;
    [SerializeField]
    private float _wireRadius;

    private Vector2 velocity = Vector2.zero;
    void Start()
    {
        _checkPointIndex = 0;
        _direction = (_allCheckPoints[_checkPointIndex] - (Vector2)transform.position).normalized;
        _isAtLastCheckPoint = false;
    }
    private void Update()
    {
        if (!_isAtLastCheckPoint) Target();
        if (_checkPointIndex == _allCheckPoints.Count) _isAtLastCheckPoint = true;
    }
    void FixedUpdate()
    {
        if (!_isAtLastCheckPoint) Move();
        else transform.position = Vector2.SmoothDamp(transform.position, Map.CheckPointIndexToPosition(_number), ref velocity, _smoothing * _speed);
    }

    private void Target()
    {
        if (Vector2.Distance(transform.position, _allCheckPoints[_checkPointIndex]) < _wireRadius) _checkPointIndex++;
    }
    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
        _direction = Vector2.SmoothDamp(_direction, (_allCheckPoints[_checkPointIndex] - (Vector2)transform.position).normalized, ref velocity, _smoothing);
    }
}
