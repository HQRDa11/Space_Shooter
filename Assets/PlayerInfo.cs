using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerInfo : MonoBehaviour
{
    private List<Image> m_healthBars;
    public List<Image> HealthBars { get => m_healthBars; }


    private void Awake()
    {
        m_healthBars = this.gameObject.GetComponentsInChildren<Image>().ToList<Image>();
        m_healthBars.RemoveAt(0);
        foreach (Image bar in HealthBars)
        {
            bar.fillAmount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}