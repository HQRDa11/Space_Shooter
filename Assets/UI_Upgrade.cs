using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Upgrade : MonoBehaviour
{ 
    private int[] m_totalComponents;
    private Text[] m_totalComponents_Display;
    private SquadronData m_squadronData;

    // STATE DISPLAY
    private Button m_previousState_btn;
    private Button m_nextState_btn;
    private Text   m_stateName;

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


    private void Start()
    {
        Link_UI_Elements();
        Initialise_UI_Elements("UPGRADE SQUAD");

        Load_Profile_Components();
        Display_Components();

        Load_Profile_SquadronData();

        Display_SquadData();

    }

    private void Initialise_StateButtons()
    {
        Application_StateMachine stateMachine = Application_StateMachine.Instance;
        ApplicationState_Type previous = stateMachine.Get_CurrentState().Previous();
        
        Debug.Log("StateType: " + stateMachine.Get_CurrentStateType().ToString());

        switch (previous != ApplicationState_Type.NULL)
        {
            case true:
                m_previousState_btn.onClick.AddListener(() => stateMachine.stateRequest(previous));
                break;
            case false:
                m_previousState_btn.image.color = Color.clear ;
                break;

        }
        ApplicationState_Type next = stateMachine.Get_CurrentState().Next();
        switch (next != ApplicationState_Type.NULL)
        {
            case true:
                m_nextState_btn.onClick.AddListener(() => stateMachine.stateRequest(next));
                break;
            case false:
                m_nextState_btn.image.color = Color.clear;
                break;

        }
    }
    public void Initialise_UI_Elements(string stateName)
    {
        m_stateName.text = stateName;

        Initialise_StateButtons();

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
        // STATE DISPLAY
        m_previousState_btn = LinkButton("Button_PreviousState");
        m_nextState_btn = LinkButton("Button_NextState");
        m_stateName = LinkText("Text_State");

        //MEMBER_SWITCH_DISPLAY
        m_text_member = LinkText("Text_Member");
        m_previousMember_btn = LinkButton("Button_PreviousMember");
        m_nextMember_btn = LinkButton("Button_NextMember");

        //SHIP_DISPLAY
        m_shipName_Display = LinkText("Text_ShipName");
        m_shipLevel_Display = LinkText("Text_ShipLevel"); 

        //MODULE_SWITCH_DISPLAY
        m_text_module = LinkText("Text_Module");
        m_previousModule_btn = LinkButton("Button_PreviousModule");
        m_nextModule_btn = LinkButton("Button_PreviousModule");

        //MODULE_DISPLAY
        m_moduleName_Display = LinkText("Text_ModuleName");
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
                    case false:
                        Debug.LogError("cant load Squadron Data");
                        return;
                }
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
