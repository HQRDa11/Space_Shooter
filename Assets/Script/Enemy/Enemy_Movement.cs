using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private List<Vector2> _allCheckPoints; public List<Vector2> AllCheckPoints { set => _allCheckPoints = value; }
    private int _checkPointIndex;
    private Vector2 _direction;

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
    }
    private void Update()
    {
        Target();
        if (_checkPointIndex == _allCheckPoints.Count) GetComponent<Enemy_Manager>().DestroyFromDeadzone();
    }
    void FixedUpdate()
    {
        Move();
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
