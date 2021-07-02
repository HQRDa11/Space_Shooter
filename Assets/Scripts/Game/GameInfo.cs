using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    // Used to store current game informations,
    // and is pass through states to update Profile with game results;

    private int m_score;

    // Start is called before the first frame update
    void Start()
    {
        m_score = 0;
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

}
