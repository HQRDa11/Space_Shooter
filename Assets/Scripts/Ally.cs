using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally 
{
    private Ship m_ship;
    public Ship Ship { get => m_ship; }
    public Ally(Ship ship)
    {
        m_ship = ship;
    }
}
