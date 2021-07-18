using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Upgrade : MonoBehaviour
{ 
    private int[] m_totalComponents;
    private Text[] m_totalComponents_Display;
    private SquadronData m_squadronData;

    //MEMBER_SWITCH_DISPLAY
    private MemberData m_currentDisplayedMember;
    private Text   m_text_member;
    private Button m_previousMember_btn;
    private Button m_nextMember_btn;

    //SHIP_DISPLAY
    private Text m_shipName_Display;
    private Text m_shipLevel_Display;
    // to do: Sprite m_shipSprite;
    // to do: Panel m_shipStats_Display; 

    //MODULE_SWITCH_DISPLAY
    private ModuleData m_currentDisplayedModule;
    private Text   m_text_module;
    private Button m_previousModule_btn;
    private Button m_nextModule_btn;

    //MODULE_DISPLAY
    private Text m_moduleName_Display;
    private Text m_moduleLevel_Display;
    // to do: Sprite m_moduleSprite;
    // to do: Panel m_moduleStats_Display;


    private void Awake()
    {
        Link_UI_Elements();

        Load_Profile_Components();
        Display_Components();

        Load_Profile_SquadronData();

        Display_SquadData();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Text LinkText(string textGo_name)
    {
        return GameObject.Find(textGo_name).GetComponent<Text>();
    }
    public Button LinkButton(string buttonGo_name)
    {
        return GameObject.Find(buttonGo_name).GetComponent<Button>();
    }
    public void Link_UI_Elements()
    {
        int i = 0; Debug.Log(i);
        //MEMBER_SWITCH_DISPLAY
        m_text_member = LinkText("Text_Member");
        i++; Debug.Log(i);
        m_previousMember_btn = LinkButton("Button_PreviousMember");
        i++; Debug.Log(i);
        m_nextMember_btn = LinkButton("Button_NextMember");

        //SHIP_DISPLAY
        i++; Debug.Log(i);
        m_shipName_Display = LinkText("Text_ShipName");
        i++; Debug.Log(i);
        m_shipLevel_Display = LinkText("Text_ShipLevel"); 

        //MODULE_SWITCH_DISPLAY
        m_text_module = LinkText("Text_Module");
        i++; Debug.Log(i);
        m_previousModule_btn = LinkButton("Button_PreviousModule");
        i++; Debug.Log(i);
        m_nextModule_btn = LinkButton("Button_PreviousModule");

        //MODULE_DISPLAY
        i++; Debug.Log(i);
        m_moduleName_Display = LinkText("Text_ModuleName");
        i++; Debug.Log(i);
        m_moduleLevel_Display = LinkText("Text_ModuleLevel");
    }

    private void Load_Profile_Components()
    {
        m_totalComponents = ProfileHandler.Instance.ActiveProfile.TotalComponents;
    }

    private void Load_Profile_SquadronData()
    {
        m_squadronData = ProfileHandler.Instance.ActiveProfile.SquadronData;
        switch(m_squadronData != null)
        {
            case true:
                m_currentDisplayedMember = m_squadronData.AllMembers[0];
                switch(m_currentDisplayedMember!=null)
                {
                    case true:
                        m_currentDisplayedModule = m_currentDisplayedMember.Ship.AllModules[0];
                        switch (m_currentDisplayedModule != null)
                        {
                            case true:
                                Debug.Log("SquadronData Loading ok");
                                return;
                            case false:
                                Debug.LogError("cant load Module Data");
                                return;
                        }
                        break;
                    case false:
                        Debug.LogError("cant load Squadron Data");
                        return;
                }
                break;
            case false:
                Debug.LogError("cant load Member Data");
                return;
        }
    }

    private void Display_Components()
    {
        m_totalComponents_Display = GameObject.Find("Element_TotalComponentsDisplay").GetComponentsInChildren<Text>();
        for (int i = 1; i < m_totalComponents_Display.Length; i++) // reason of 1 instead of 0 : index 0 is the "Total Components:" text, we dont want to touch it.
        {
            m_totalComponents_Display[i].text = m_totalComponents[i - 1].ToString();
        }
    }

    public void Display_SquadData()
    {
        switch (m_currentDisplayedMember != null)
        {
            case true:
                m_text_member.text = m_currentDisplayedMember.Name;

                m_shipName_Display.text = m_currentDisplayedMember.Ship.Name;
                m_shipLevel_Display.text = m_currentDisplayedMember.Ship.Level.Current.ToString();

                m_moduleName_Display.text = m_currentDisplayedModule.Name;
                m_moduleLevel_Display.text = m_currentDisplayedModule.Level.Current.ToString();
                break;
            case false:
                Debug.LogError("cant load Member");
                return;
        }
       
    }
}
