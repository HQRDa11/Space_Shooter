using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Upgrade : MonoBehaviour
{ 
    private int[] m_totalComponents;
    private Text[] m_totalComponents_Display;
    private SquadronData m_squadronData;

    private void Awake()
    {
        m_totalComponents = Load_Profile_Components();
        Display_Components();
        m_squadronData = Load_Profile_SquadronData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int[] Load_Profile_Components()
    {
        return ProfileHandler.Instance.ActiveProfile.TotalComponents;
    }
    private SquadronData Load_Profile_SquadronData()
    {
        return ProfileHandler.Instance.ActiveProfile.SquadronData;
    }
    private void Display_Components()
    {
        m_totalComponents_Display = GameObject.Find("Element_TotalComponentsDisplay").GetComponentsInChildren<Text>();
        for (int i = 1; i < m_totalComponents_Display.Length; i++) // reason of 1 instead of 0 : index 0 is the "Total Components:" text, we dont want to touch it.
        {
            m_totalComponents_Display[i].text = m_totalComponents[i - 1].ToString();
        }
    }
}
