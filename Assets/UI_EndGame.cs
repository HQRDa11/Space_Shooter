using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndGame : MonoBehaviour
{
    EndGame_Logic m_logic;
    private int[] m_totalComponents;
    private int[] m_lootedcomponents;
    public int[] LootedComponents { set { m_lootedcomponents = value; } }

    private Text[] m_totalComponents_Display;
    private Text[] m_addedComponents_Display;

    private bool   m_hasFinishedDisplay;
    private int    m_rarityIndex;
    private int    m_additionValue;
    private float  m_timerMax;
    private float  m_timer;

    private Button[] m_allChoices_buttons;

    // Start is called before the first frame update
    void Awake()
    {
        Initialise_ComponentsDisplay();
        Initialise_Choice();
    }

    public void Initialise(EndGame_Logic logic)
    {
        m_logic = logic;
        LootedComponents = logic.GameInfo.GetComponent<GameInfo>().Get_lootedComponents();
        ProfileHandler.Instance.ActiveProfile.Data.UpdateProfile_WithGameResults(logic.GameInfo);
        Display_GameInfo();
    }
    // Update is called once per frame
    void Update()
    {
        Update_Component_Display();
    }

    // FINAL LOOT DISPLAY
    public void Initialise_Choice()
    {
        m_allChoices_buttons = new Button[3];
        m_allChoices_buttons = GameObject.Find("ChoicePanel_FinalLoot").GetComponentsInChildren<Button>();
        m_allChoices_buttons[0].onClick.AddListener(() => UserChoice(0));
        m_allChoices_buttons[1].onClick.AddListener(() => UserChoice(1));
        m_allChoices_buttons[2].onClick.AddListener(() => UserChoice(2));

    }
    public void UserChoice(int choice)
    {
        m_logic.OnUserChoice(choice);
        Material_Factory factory = Factory.Instance.Material_Factory;
        for (int i = 0; i< m_allChoices_buttons.Length; i++)
        {
            Button selected = m_allChoices_buttons[i];
            switch (i == choice)
            {
                case true:
                    selected.image.sprite = m_logic.FinalLoot.Options[i].Sprite();
                    selected.image.color = factory.GetMaterial(m_logic.FinalLoot.Options[i].Rarity).color;
                    break;
                case false:
                    selected.image.sprite = m_logic.FinalLoot.Options[i].Sprite();
                    selected.image.color = factory.GetMaterial(m_logic.FinalLoot.Options[i].Rarity).color;
                    selected.image.transform.localScale /= 2;
                    break;
            }
        }
        Disable_ChoiceButtons();
    }

    private void Disable_ChoiceButtons()
    {
        foreach (Button b in m_allChoices_buttons)
        {
            b.onClick.RemoveAllListeners();
        }
    }
    // TIMED COMPONENT DISPLAY
    public void Initialise_ComponentsDisplay()
    {
        m_lootedcomponents = new int[6];
        m_totalComponents = new int[6];
        m_totalComponents = (int[])ProfileHandler.Instance.ActiveProfile.Data.Components.Clone();

        m_hasFinishedDisplay = false;

        m_totalComponents_Display = GameObject.Find("Element_TotalComponentsDisplay").GetComponentsInChildren<Text>();
        m_addedComponents_Display = GameObject.Find("Element_AddedComponentsDisplay").GetComponentsInChildren<Text>();


        for (int i = 0; i < 6; i++) // reason of 1 instead of 0 : index 0 is the "Total Components:" text, we dont want to touch it.
        {
            m_totalComponents_Display[i].text = m_totalComponents[i].ToString();
        }

        m_rarityIndex = 0;
       // Debug.LogWarning("RarityGrey = " + m_rarityIndex);
        m_additionValue = 0;
        m_timer = 0;
        m_timerMax = 0.32f;
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
    private void Update_Component_Display()
    {
        switch (m_hasFinishedDisplay)
        {
            case true:
                //      <= NOTE 1 : ici possible de caluler et afficher une mention a partir des loot et du score?
                return;
            case false:
                switch (isTimerOk())
                {
                    case true:
                        switch (m_rarityIndex < 5)
                        {
                            case true:
                                //Debug.Log("Updating State: " + ((Rarity)m_rarityIndex).ToString() + "or index:" + m_rarityIndex);
                                Update_Step();
                                return;
                            case false:
                                Update_LastStep();
                                break;
                        }
                        break;
                    case false:
                        break;
                }
                return;
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
                        m_totalComponents_Display[m_rarityIndex].text = (m_totalComponents[m_rarityIndex] + m_additionValue).ToString();
                        m_additionValue = 0;
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

    private void Update_LastStep()
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

    // GAME RECAP
    public void Display_GameInfo()
    {
        GameObject.Find("Text_LastWave").GetComponent<Text>().text = "last wave: " + m_logic.GameInfo.Get_LastWave().ToString();
        GameObject.Find("Text_Score").GetComponent<Text>().text = "score: " + m_logic.GameInfo.Get_Score().ToString();
    }
}
