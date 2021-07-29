using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorm_Body : Boss_Body
{
    private bool _isHeadDestroyed;
    private bool _canStartMoving;
    private float _timeToExplode;

    private float _spacing;
    private Vector2 _previousPosition; public Vector2 PreviousPosition { get => _previousPosition; }

    private void Start()
    {
        base.CanMove(false);
        _isHeadDestroyed = false;
        _canStartMoving = false;
        _timeToExplode = .2f;

        _spacing = .02f;
    }
    public new void Update()
    {
        if (!_canStartMoving)
        {
            CanStartMoving();
        }

        if (!_isHeadDestroyed)
        {
            base.Update();
            _previousPosition = transform.position;
        }
        else if (Clock < _timeToExplode * Index)
        {
            Update_Clock();
        }
        else if (Clock >= _timeToExplode * Index)
        {
            base.OnDestruction();
        }
    }
    public void CanStartMoving()
    {
        if (FindObjectOfType<TheWorm_Head>() != null)
        {
            Vector2 previousBodyPartPosition = FindObjectOfType<TheWorm_Head>().PreviousBodyPartPosition(this);

            if (Vector2.Distance(transform.position, previousBodyPartPosition) >= _spacing)
            {
                _canStartMoving = true;
                base.CanMove(true);
            }
        }
    }
    public void OnHeadDeath()
    {
        _isHeadDestroyed = true;
        base.CanMove(false);
        base.ResetClock();
    }
}
