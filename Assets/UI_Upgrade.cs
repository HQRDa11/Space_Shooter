using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Upgrade : MonoBehaviour
{ 
    private enum Focus { MAIN = 0, CHANGE_MODULE}; // UI change displayed elements depending on user input
    private Focus m_currentFocus;
    //GameObject are linked to be easily enabled/disabled on focus change.
    private UiFocus[] m_allFocuses; // Focus is like an UI_State

    private int[] m_totalComponents;
    private Text[] m_totalComponents_Display;
    private SquadronData m_squadronData;

    // STATE DISPLAY
    private Button m_previousState_btn;
    private Button m_nextState_btn;
    private Text   m_stateName;

    //MEMBER_SWITCH_DISPLAY
    private MemberData m_currentDisplayedMember;
    private int m_memberIndex;
    private Text   m_text_member;
    private Button m_previousMember_btn;
    private Button m_nextMember_btn;

    //SHIP_DISPLAY
    private Text m_shipName_Display;
    private Text m_shipLevel_Display;
    // to do: SpriteRenderer m_shipSprite;
    // to do: Panel m_shipStats_Display; 


    //MODULE_SWITCH_DISPLAY
    private ModuleData m_currentDisplayedModule;
    private int    m_moduleIndex;
    private Text   m_text_module;
    private Button m_previousModule_btn;
    private Button m_nextModule_btn;

    //MODULE_DISPLAY
    private Text m_moduleName_Display;
    private Text m_moduleLevel_Display;
    private Image m_moduleImage_Display;
    // to do: Panel m_moduleStats_Display;

    //LIST OF MODULES_ELEMENTS
    private List<Button> m_moduleButtons;

    private void Start()
    {
        Load_Profile_Components();
        Load_Profile_SquadronData();

        FindAll_UI_Elements();

        Initialise_StateSwitch("UPGRADES");
        Initialise_MemberSwitch();
        Initialise_ModuleSwitch();

        Display_Components();
        Display_SquadMember();
    }
    void Update()
    {
        
    }

    // LINK UI_PREFABS 
    public void FindAll_UI_Elements()
    {
        m_allFocuses = new UiFocus[2];
        m_allFocuses = Resources.FindObjectsOfTypeAll<UiFocus>();
        m_currentFocus = Focus.MAIN;

        // STATE DISPLAY
        m_previousState_btn = Find_Button_Element("Button_PreviousState");
        m_nextState_btn = Find_Button_Element("Button_NextState");
        m_stateName = Find_Text_Element("Text_State");

        //MEMBER_SWITCH_DISPLAY
        m_text_member = Find_Text_Element("Text_Member");
        m_previousMember_btn = Find_Button_Element("Button_PreviousMember");
        m_nextMember_btn = Find_Button_Element("Button_NextMember");

        //SHIP_DISPLAY
        m_shipName_Display = Find_Text_Element("Text_ShipName");
        m_shipLevel_Display = Find_Text_Element("Text_ShipLevel"); 

        //MODULE_SWITCH_DISPLAY
        m_text_module = Find_Text_Element("Text_Module");
        m_previousModule_btn = Find_Button_Element("Button_PreviousModule");
        m_nextModule_btn = Find_Button_Element("Button_NextModule");

        //MODULE_DISPLAY
        m_moduleName_Display = Find_Text_Element("Text_ModuleName");
        m_moduleLevel_Display = Find_Text_Element("Text_ModuleLevel");
        m_moduleImage_Display = GameObject.Find("Image_Module").GetComponent<Image>();
        Initialise_Buttons_StockChangeUpgrade();
    }
    public Text Find_Text_Element(string textGo_name)
    {
        return GameObject.Find(textGo_name).GetComponent<Text>();
    }
    public Button Find_Button_Element(string buttonGo_name)
    {
        return GameObject.Find(buttonGo_name).GetComponent<Button>();
    }

    // INITIALISE GENERIC UI ELEMENTS
    private void Initialise_StateSwitch(string stateName)
    {
        m_stateName.text = stateName;

        Application_StateMachine stateMachine = Application_StateMachine.Instance;
        ApplicationState_Type previous = stateMachine.Get_CurrentState().Previous();

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
    //MEMBER SWITCH
    private void Initialise_MemberSwitch()
    {
        m_memberIndex = 0;
        m_nextMember_btn.onClick.AddListener(() => NextMember());
        m_previousMember_btn.onClick.AddListener(() => PreviousMember());
    }    
    private void NextMember()
    {
        m_memberIndex = Tools.StepIndex(true, m_memberIndex, m_squadronData.AllMembers.Length);
        m_currentDisplayedMember = m_squadronData.AllMembers[m_memberIndex];
        Display_SquadMember();
        Display_Module();
    }
    private void PreviousMember()
    {
        m_memberIndex = Tools.StepIndex(false, m_memberIndex, m_squadronData.AllMembers.Length);
        m_currentDisplayedMember = m_squadronData.AllMembers[m_memberIndex];
        Display_SquadMember();
        Display_Module();
    }
    //MODULE SWITCH
    private void Initialise_ModuleSwitch()
    {
        m_moduleIndex = 0;
        m_nextModule_btn.onClick.AddListener(() => NextModule());
        m_previousModule_btn.onClick.AddListener(() => PreviousModule());
    }
    private void Initialise_Buttons_StockChangeUpgrade()
    {
        GameObject panel = GameObject.Find("ChoicePanel_Module");
        Button[] buttons = panel.GetComponentsInChildren<Button>();
        //buttons[0].onClick.AddListener(() =>); STOCK MODULE
        buttons[1].onClick.AddListener(() => RequestFocus(Focus.CHANGE_MODULE));
        //buttons[2].onClick.AddListener(() =>); UPGRADE MODULE

    }
    private void NextModule()
    {
        m_moduleIndex = Tools.StepIndex(true, m_moduleIndex, m_currentDisplayedMember.Ship.AllModules.Length);
        m_currentDisplayedModule = m_currentDisplayedMember.Ship.AllModules[m_moduleIndex];
        Display_Module();
    }
    private void PreviousModule()
    {
        m_moduleIndex = Tools.StepIndex(false, m_moduleIndex, m_currentDisplayedMember.Ship.AllModules.Length);
        m_currentDisplayedModule = m_currentDisplayedMember.Ship.AllModules[m_moduleIndex];
        Display_Module();
    }
    //LOADING
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
                                //Debug.Log("SquadronData Loading ok");
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
                Debug.LogError( "no Squadron Data");
                return;
        }
    }
    //DISPLAY
    private void Display_Components()
    {
        m_totalComponents_Display = GameObject.Find("Element_TotalComponentsDisplay").GetComponentsInChildren<Text>();
        for (int i = 1; i < m_totalComponents_Display.Length; i++) // reason of 1 instead of 0 : index 0 is the "Total Components:" text, we dont want to touch it.
        {
            m_totalComponents_Display[i].text = m_totalComponents[i - 1].ToString();
        }
    }
    public void Display_SquadMember()
    {
        MemberData displayed = m_currentDisplayedMember;
        switch (displayed != null)
        {
            case true:
                m_text_member.text = displayed.Name + " " + (m_memberIndex+1).ToString() + "/" + m_squadronData.AllMembers.Length;

                m_shipName_Display.text = displayed.Ship.Name;
                m_shipLevel_Display.text = displayed.Ship.Level.Current.ToString();
                m_currentDisplayedModule = displayed.Ship.AllModules[0];
                m_moduleIndex = 0;
                Display_Module();
                break;
            case false:
                Debug.LogError("cant load Member");
                return;
        }

    }
    public void Display_Module()
    {
        switch (m_currentDisplayedModule != null)
        {
            case true:
                ShipData   ship   = m_currentDisplayedMember.Ship;
                ModuleData module = ship.AllModules[m_moduleIndex];
                Color      color  = Factory.Instance.Material_Factory.GetMaterial((m_currentDisplayedModule.Rarity)).color;
                // Debug.Log(color);

                //Switch display
                int index = m_moduleIndex + 1;
                int total = ship.AllModules.Length;
                m_text_module.text           = "Module " + index + "/" + total;

                //Name display
                m_moduleName_Display.text    = "T" + module.Tier + " " + module.Name;
                m_moduleName_Display.color   = color;

                //Level display
                m_moduleLevel_Display.text   = "LVL "+module.Level.Current.ToString();
                //Sprite display

                m_moduleImage_Display.sprite = module.Sprite();
                m_moduleImage_Display.color  = color;
                break;
            case false:
                Debug.LogError("cant display module");
                return;
        }

    }

    private void RequestFocus(Focus newFocus) // <- Is it ok to let it private with btn.AddListeners()()=>RequestFocus()) ?
    {
        //Debug.Log(" CURRENT FOCUS:" + m_currentFocus + "SWITCH TO:" + newFocus);
        switch (m_currentFocus)
        {
            case Focus.MAIN:
                switch(newFocus)
                {
                    case Focus.CHANGE_MODULE:
                        m_allFocuses[1].gameObject.SetActive(false); // <- Strangely Main_Syaye_Focus is set to 1 on FindObjectOfTypeAll();
                        m_allFocuses[0].gameObject.SetActive(true); // <- so this is Change_State_Focus

                        int totalModules = m_squadronData.AllStoredModules.Length;
                        m_moduleButtons = new List<Button>();
                        GameObject newParent = Resources.FindObjectsOfTypeAll<Grid_Scaler>()[0].gameObject;
                        for (int i = 0; i < totalModules; i++) 
                        {
                            if (m_squadronData.AllStoredModules[i] != null)
                            {
                                GameObject newDisplay = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI_Elements/ListElement"), newParent.transform);
                                m_moduleButtons.Add( newDisplay.GetComponent<Button>());
                                newDisplay.GetComponentsInChildren<Text>()[0].text = m_squadronData.AllStoredModules[i].FullName;
                                newDisplay.GetComponentsInChildren<Image>()[1].sprite = m_squadronData.AllStoredModules[i].Sprite();
                                Rarity rarity = m_squadronData.AllStoredModules[i].Rarity;
                                newDisplay.GetComponentsInChildren<Image>()[1].color = Factory.Instance.Material_Factory.GetMaterial(rarity).color;
                                // Monobehaviour issue: using the iterator 'i' in AddListener() results in all buttons sharing the same 
                                // last iteration value of i;
                                int tempSourceIndex = i; //<- (solucion internet): temp variable fixes the issue.
                                int tempTargetIndex = m_moduleIndex;
                                newDisplay.GetComponent<Button>().onClick.AddListener(() => OnModuleChange(tempSourceIndex, tempTargetIndex));
                            }

                        }
                        m_currentFocus = Focus.CHANGE_MODULE;
                        break;
                }
                break;
            case Focus.CHANGE_MODULE:
                switch (newFocus)
                {
                    case Focus.MAIN:
                        Button[] allRemoved =  GameObject.Find("List_GridScaler_Module").GetComponentsInChildren<Button>();
                        for (int i = 0; i< allRemoved.Length; i++)
                        {
                            GameObject.Destroy(allRemoved[i].gameObject);
                        }
                        m_allFocuses[0].gameObject.SetActive(false);
                        m_allFocuses[1].gameObject.SetActive(true);
                        Display_Module();
                        m_currentFocus = Focus.MAIN;
                        break;
                }
                break;
        }
    }
    public void OnModuleChange(int sourceIndex, int targetIndex)
    {
        m_currentDisplayedMember.Ship.EquipModule(sourceIndex, targetIndex);
        m_currentDisplayedModule = m_currentDisplayedMember.Ship.AllModules[targetIndex];
        //Debug.LogWarning("Module Switched. (new module: " + m_currentDisplayedModule.FullName + ")");
        RequestFocus(Focus.MAIN);
    }
}
