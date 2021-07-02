using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
    [SerializeField]
    private int m_gameCurrency;
    public int GameCurrency { get { return m_gameCurrency; } set { m_gameCurrency = value; } }
    [SerializeField]
    private string m_id;
    public string ID { get { return m_id; } set { m_id = value; } }

    [SerializeField]
    private int[] m_highScores;
    public int[] HighScores { get { return m_highScores; } set { m_highScores = value; } }

    // Start is called before the first frame update
    void Awake()
    {
        m_gameCurrency = 0;
        m_id = "noID";
        HighScores = new int[10];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
