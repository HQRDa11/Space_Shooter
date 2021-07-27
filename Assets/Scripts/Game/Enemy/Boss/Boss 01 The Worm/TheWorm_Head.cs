using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorm_Head : Boss_Head
{
    private List<TheWorm_Body> _allBodyParts; public List<TheWorm_Body> AllBodyPart { get => _allBodyParts; }
    private void Awake()
    {
        _allBodyParts = new List<TheWorm_Body>();
    }
    public void OnBodyPartDeath(TheWorm_Body bodyPart)
    {
        // Pour chaque partie du corps inferieur a celle detruite, deplace la position a la position récente de la partie de corps précédente
        for (int i = _allBodyParts.IndexOf(bodyPart) + 1; i < _allBodyParts.Count; i++)
        {
            _allBodyParts[i].transform.position = _allBodyParts[i - 1].PreviousPosition;
            _allBodyParts[i].Index--;
        }
        _allBodyParts.Remove(bodyPart);
    }
    public Vector2 PreviousBodyPartPosition(TheWorm_Body bodyPart)
    {
        if (_allBodyParts.IndexOf(bodyPart) == 0)
        {
            return transform.position;
        }
        else return _allBodyParts[_allBodyParts.IndexOf(bodyPart) - 1].transform.position;
    }
}
