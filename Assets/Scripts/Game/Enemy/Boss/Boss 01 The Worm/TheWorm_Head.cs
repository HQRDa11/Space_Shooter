using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorm_Head : Boss_Head
{
    private List<TheWorm_Body> _allBodyParts; public List<TheWorm_Body> AllBodyPart { get => _allBodyParts; }
    private Transform _bodyStartPoint;

    private void Awake()
    {
        _allBodyParts = new List<TheWorm_Body>();
        _bodyStartPoint = transform.GetChild(1);
    }
    private new void Update()
    {
        base.Update();
    }
    public void OnBodyPartDeath(TheWorm_Body bodyPart)
    {
        foreach (TheWorm_Body part in _allBodyParts)
        {
            part.SetPrevious_Position();
            part.SetPrevious_CheckPointIndex();
            part.SetPrevious_MoveDirection();
        }

        // Pour chaque partie du corps inferieur a celle detruite, deplace la position a la position récente de la partie de corps précédente
        for (int i = _allBodyParts.IndexOf(bodyPart) + 1; i < _allBodyParts.Count; i++)
        {
            _allBodyParts[i].transform.position = _allBodyParts[i - 1].PreviousPosition;
            _allBodyParts[i].CheckPointIndex = _allBodyParts[i - 1].PreviousCheckPointIndex;
            _allBodyParts[i].MoveDirection = _allBodyParts[i - 1].PreviousMoveDirection;
            _allBodyParts[i].Index--;
        }

        _allBodyParts.Remove(bodyPart);
    }
    public Vector2 PreviousBodyPartPosition(TheWorm_Body bodyPart)
    {
        if (_allBodyParts.IndexOf(bodyPart) == 0)
        {
            return _bodyStartPoint.position;
        }
        else
        {
            return _allBodyParts[_allBodyParts.IndexOf(bodyPart) - 1].transform.position;
        }
    }
}
