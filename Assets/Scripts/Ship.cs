using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Ship : MonoBehaviour
{
    private List<TurretSlot> m_allTurretSlots;

    // Start is called before the first frame update
    void Start()
    {
        m_allTurretSlots = new List<TurretSlot>();
        m_allTurretSlots = GetComponentsInChildren<TurretSlot>().ToList<TurretSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
