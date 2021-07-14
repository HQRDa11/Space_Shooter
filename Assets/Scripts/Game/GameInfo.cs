using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    // Used to store current game informations,
    // and is pass through states to update Profile with game results;

    private int m_score;
    private Dictionary<Rarity, int> m_lootedComponents;

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

    public void AddNewComponent(Rarity rarity)
    {
        m_lootedComponents[rarity]++;
        Debug.LogWarning(" Looted: " + rarity + " component ");
    }

}
