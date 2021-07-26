using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsList
{
    private int[] _allCheckPoints; public int[] AllCheckPoints { get => _allCheckPoints; }

    public CheckPointsList(int[] list)
    {
        _allCheckPoints = list;
    }
}
