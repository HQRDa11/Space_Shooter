using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
    [SerializeField]
    private SquadronData m_squadronData;
    public SquadronData SquadronData { get { return m_squadronData; } set { m_squadronData = value; } }

    [SerializeField]
    private int m_gameCurrency;
    public int GameCurrency { get { return m_gameCurrency; } set { m_gameCurrency = value; } }
    [SerializeField]
    private string m_id;
    public string ID { get { return m_id; } set { m_id = value; } }

    [SerializeField]
    private int[] m_highScores;
    public int[] HighScores { get { return m_highScores; } set { m_highScores = value; } }

    [SerializeField]
    private int[] m_components;
    public int[] TotalComponents { get { return m_components; } set { m_components = value; } }

    // Start is called before the first frame update
    void Awake()
    {
        m_gameCurrency = 0;
        m_id = "noID";
        m_highScores = new int[10];
        m_components = new int[6];
        m_squadronData = new SquadronData();
        Debug.LogWarning("squadDataOnAwake? " + m_squadronData);
    }

    public void ModifyNumberOf_Components( int rarityIndex, int modifier)
    {
        m_components[rarityIndex] += modifier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
