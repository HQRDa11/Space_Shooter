using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndGame : MonoBehaviour
{
    private int[] m_totalComponents;
    private int[] m_lootedcomponents;
    public int[] LootedComponents { set { m_lootedcomponents = value; Debug.LogWarning("Component set with values:" + m_lootedcomponents[0].ToString() + m_lootedcomponents[1].ToString() + m_lootedcomponents[2].ToString()); } }

    private Text[] m_totalComponents_Display;
    private Text[] m_addedComponents_Display;

    private bool   m_hasFinishedDisplay;
    private int    m_rarityIndex;
    private int    m_additionValue;
    private float  m_timerMax;
    private float  m_timer;

    // Start is called before the first frame update
    void Awake()
    {
        m_lootedcomponents = new int[6];
        m_totalComponents = new int[6];
        m_totalComponents = (int[])ProfileHandler.Instance.ActiveProfile.TotalComponents.Clone();

        m_hasFinishedDisplay = false;

        m_totalComponents_Display = GameObject.Find("Element_TotalComponentsDisplay").GetComponentsInChildren<Text>();
        m_addedComponents_Display = GameObject.Find("Element_AddedComponentsDisplay").GetComponentsInChildren<Text>();

        for (int i = 1; i < m_totalComponents_Display.Length; i++) // reason of 1 instead of 0 : index 0 is the "Total Components:" text, we dont want to touch it.
        {
            m_totalComponents_Display[i].text = m_totalComponents[i-1].ToString() ;
        }

        m_rarityIndex = (int) Rarity.GREY;
        Debug.LogWarning("RarityGrey = " + m_rarityIndex);
        m_additionValue = 0;
        m_timer = 0;
        m_timerMax = 0.16f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_hasFinishedDisplay)
        {
            case true:
                //                       <= NOTE 1 : ici possible de caluler et afficher une mention a partir des loot et du score?
                return;
            case false:
                switch(isTimerOk())
                {
                    case true:
                        switch (m_rarityIndex < 5)
                        {
                            case true:
                                Debug.Log("Updating State: " + ((Rarity)m_rarityIndex).ToString() + "or index:" + m_rarityIndex);
                                Update_Step();
                                return;
                            case false:
                                Update_Last();
                                break;
                        }
                        break;
                    case false:
                        break;
                }
                return;
        }
    }
    private bool isTimerOk()
    {
        m_timer += Time.deltaTime;
        switch(m_timer >= m_timerMax)
        {
            case true:
                m_timer = 0;
                return true;
            case false:
                return false;
        }
    }

    private void PlusOne()
    {
        m_additionValue++;
        switch (m_additionValue <= m_lootedcomponents[m_rarityIndex])
        {
            case true:
                Sound.Instance.Play_ComponentCollect();
                m_addedComponents_Display[m_rarityIndex].text = "+" + m_additionValue;
                break;
        }
    }

    private bool TryNextRarity()
    {
        return m_additionValue >= m_lootedcomponents[m_rarityIndex];
    }

    private void Update_Step()
    {
        PlusOne();
        switch (TryNextRarity())
        {
            case true:
                //Debug.LogWarning(" m_totalComponents[m_rarityIndex]=" + m_totalComponents[m_rarityIndex] + "//  m_additionValue - 1)=" + (m_additionValue));
                switch (m_lootedcomponents[m_rarityIndex] != 0)
                {
                    case true:
                        Sound.Instance.Play_ComponentCollect();
                        m_totalComponents_Display[m_rarityIndex + 1].text = (m_totalComponents[m_rarityIndex] + m_additionValue).ToString();
                        break;
                    case false:
                        break;
                }
                
                m_timerMax += 0.42f * m_timerMax;
                m_additionValue = 0;
                m_rarityIndex++;
                break;
        }
    }

    private void Update_Last()
    {
        PlusOne();
        switch (TryNextRarity())
        {
            case true:
               // Debug.LogWarning(" m_totalComponents[m_rarityIndex]=" + m_totalComponents[m_rarityIndex] + "//  m_additionValue - 1)=" + (m_additionValue));
                switch (m_lootedcomponents[m_rarityIndex] != 0)
                {
                    case true:
                        Sound.Instance.Play_ComponentCollect();
                        m_totalComponents_Display[m_rarityIndex + 1].text = (m_totalComponents[m_rarityIndex] + m_additionValue).ToString();
                        break;
                    case false:
                        break;
                }
                m_hasFinishedDisplay = true;
                m_timerMax += 0.42f * m_timerMax;
                m_additionValue = 0;
                m_rarityIndex = 0;
                break;
        }
    }

    public void Display_GameInfo(GameInfo gameInfo)
    {
        gameInfo = GameObject.Find("GameInfo").GetComponent<GameInfo>();
        this.transform.GetChild(0).GetComponent<Text>().text =
            "Game Over \n" +
            "\n" +
            "\n" +
            "\n" +
            "Score : " + gameInfo.Get_Score() + "\n" +
            "Last Wave : " + gameInfo.Get_LastWave() + "\n" +
            "RewardChestOpening : ";
    }
}
