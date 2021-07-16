using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    // Used to store current game informations,
    // and is pass through states to update Profile with game results;

    private int m_score;
    private int m_lastWave;

    private Dictionary<Rarity, int> m_lootedComponents;

    private Text[] m_AllComponentsTexts;

    // Start is called before the first frame update
    void Start()
    {
        m_score = 0;
        m_lootedComponents = new Dictionary<Rarity, int>();
        m_lootedComponents.Add(Rarity.GREY, 0);
        m_lootedComponents.Add(Rarity.WHITE, 0);
        m_lootedComponents.Add(Rarity.GREEN, 0);
        m_lootedComponents.Add(Rarity.BLUE, 0);
        m_lootedComponents.Add(Rarity.PURPLE, 0);
        m_lootedComponents.Add(Rarity.ORANGE, 0);

        m_AllComponentsTexts = GameObject.Find("Element_ComponentsDisplay").GetComponentsInChildren<Text>();
        DisplayComponents();
    }
    
    // Save is used by Game to save its information before destruction
    public void Save(int score)
    {
        m_score = score;
    }

    // Load is used by the ProfileHandler to update with new game results
    public int Get_Score()
    {
        return m_score;
    }
    public int[] Get_lootedComponents()
    {
        int[] components = new int[6];
        for (int i = 0; i < components.Length; i++)
        {
            components[i] = m_lootedComponents[(Rarity)i];
        }
        return components;
    }

    public void AddNewComponent(Rarity rarity)
    {
        m_lootedComponents[rarity]++;
        Debug.LogWarning(" Looted: " + rarity + " component ");
    }
    public void DisplayComponents()
    {
        for (int i = 1; i <m_AllComponentsTexts.Length; i++) // reason of 1 instead of 0 : index 0 is the "components:" text, we dont want to touch it.
        {
            Rarity rarity = (Rarity)i -1; // reason of -1 : see upper.
            m_AllComponentsTexts[i].text = m_lootedComponents[rarity].ToString();
        }
    }

    public int Get_LastWave()
    {
        return m_lastWave;
    }

}
