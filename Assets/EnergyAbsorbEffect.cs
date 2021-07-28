using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyAbsorbEffect : MonoBehaviour
{
    private Vector2 _offset;
    void Start()
    {
        _offset = Vector2.up;
        transform.localPosition = _offset;
    }

    void Update()
    {
        transform.localPosition = _offset;
    }
}
