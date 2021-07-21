using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiElement_StatsPanel : MonoBehaviour
{
    private Transform m_parentGrid;

    // Start is called before the first frame update
    void Awake()
    {
        m_parentGrid = GetComponentsInChildren<Image>()[1].GetComponentInChildren<UiElement_VerticalGridLayout>().transform;
    }

    public void Display_ModuleStats(ModuleStat[] stats)
    {
        ResetPanel();
        switch (stats != null)
        {
            case true:
                foreach (ModuleStat stat in stats)
                {
                    GameObject statDisplay = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI_Elements/StatDisplay"), m_parentGrid);
                    statDisplay.GetComponentInChildren<Text>().text = stat.Name;
                    string values = (System.Math.Round(stat.Value, 2)).ToString() + " / " + (System.Math.Round(stat.MaxValue, 2)).ToString();
                    statDisplay.GetComponentInChildren<Image>().GetComponentsInChildren<Text>()[1].text = values;
                    statDisplay.GetComponentsInChildren<Image>()[1].fillAmount = stat.Value / stat.MaxValue;
                    // Debug.LogWarning(" ratio = " + statDisplay.GetComponentInChildren<Image>().name);
                }
                break;
        }
    }
    public void ResetPanel()
    {
        // Debug.LogWarning(gameObject.GetComponentInChildren<UiElement_VerticalGridLayout>() == true);
        gameObject.GetComponentInChildren<UiElement_VerticalGridLayout>().Reset_AllElements();
    }
}
