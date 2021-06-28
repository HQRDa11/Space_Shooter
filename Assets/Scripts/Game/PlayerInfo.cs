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
        m_healthBars = new List<Image>();
        m_healthBars.Add(GameObject.Find("PlayerHealthBar").GetComponent<Image>());
        List<Image> temp = new List<Image>();
        temp = GameObject.Find("AlliesHealthBar").gameObject.GetComponentsInChildren<Image>().ToList<Image>();
        temp.RemoveAt(0);
        foreach (Image i in temp)
        {
            m_healthBars.Add(i);
        }
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
