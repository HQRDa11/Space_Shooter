using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ApplicationState_Type { NULL, INTRO, MAINMENU, PREPARE, UPGRADE, GAME, ENDGAME, PAUSE, OPTIONS, CREDITS, QUIT }
public class Application_StateMachine : MonoBehaviour 
{
    private static Application_StateMachine _instance;
    public static Application_StateMachine Instance { get => _instance; }


    private List<ApplicationState> m_states;
    private ApplicationState m_currentState;

    public void Awake()
    {
        _instance = this;
        m_states = new List<ApplicationState>();
        m_states.Add(new Intro_ApplicationState("State_Intro"));
        m_currentState = m_states[0];
    }

    public void Update()
    {
        m_currentState.update();
    }

    public bool stateRequest(ApplicationState_Type stateResquest) 
        // used by client to change current state.
        // the stateMachine will check conditions and operate the transition
        // before calling switchState() for the actual switching.
    {
        bool isSwitch = false;

        switch (m_currentState.Type)
        {

            case ApplicationState_Type.INTRO:

                switch (stateResquest)
                {
                    case ApplicationState_Type.MAINMENU:
                        EndCurrentState();
                        SetCurrentState(new MainMenu_ApplicationState("State_MainMenu"));
                        isSwitch = true;
                        break;
                }

                break;

            case ApplicationState_Type.MAINMENU:

                switch (stateResquest)
                {
                    case ApplicationState_Type.PREPARE:
                        EndCurrentState();
                        SetCurrentState(new Prepare_ApplicationState("State_Prepare"));
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.OPTIONS:
                        EndCurrentState();
                        SetCurrentState(new Options_ApplicationState("State_Options"));
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.CREDITS:
                        EndCurrentState();
                        SetCurrentState(new Credits_ApplicationState("State_Credits"));
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.QUIT:
                        EndCurrentState();
                        //for each states s in m_states s.end?
                        SetCurrentState(new Quit_ApplicationState("State_Quit"));
                        isSwitch = true;
                        break;
                }

                break;

            case ApplicationState_Type.PREPARE:

                switch (stateResquest)
                {
                    case ApplicationState_Type.GAME:
                        EndCurrentState();
                        SetCurrentState(new Game_ApplicationState("State_Game"));
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.UPGRADE:
                        EndCurrentState();
                        SetCurrentState(new Upgrade_ApplicationState("State_Upgrade"));
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.MAINMENU:
                        EndCurrentState();
                        SetCurrentState(new MainMenu_ApplicationState("State_MainMenu"));
                        isSwitch = true;
                        break;
                }
                break;


            case ApplicationState_Type.UPGRADE:

                switch (stateResquest)
                {
                    case ApplicationState_Type.PREPARE:
                        EndCurrentState();
                        SetCurrentState(new Prepare_ApplicationState("State_Prepare"));
                        isSwitch = true;
                        break;
                    case ApplicationState_Type.NULL:
                        Debug.LogWarning("This Should not happen");
                        isSwitch = false;
                        break;
                    default:
                        Debug.LogWarning("This Should not happen");
                        isSwitch = false;
                        break;
                }
                break;

            case ApplicationState_Type.GAME:

                switch (stateResquest)
                {
                    case ApplicationState_Type.PAUSE:
                        SetCurrentState(new Pause_ApplicationState("State_Pause"));
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.ENDGAME:
                        EndCurrentState();
                        SetCurrentState(new EndGame_ApplicationState("State_EndGame"));
                        isSwitch = true;
                        break;
                }
                break;

            case ApplicationState_Type.ENDGAME:

                switch (stateResquest)
                {
                    case ApplicationState_Type.MAINMENU:
                        EndCurrentState();
                        SetCurrentState(new MainMenu_ApplicationState("State_MainMenu"));
                        isSwitch = true;
                        break;
                }
                break;

            case ApplicationState_Type.PAUSE:

                switch (stateResquest)
                {
                    case ApplicationState_Type.GAME:
                        PopCurrentState();
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.MAINMENU:
                        PopCurrentState();
                        EndCurrentState();
                        SetCurrentState(new MainMenu_ApplicationState("State_MainMenu"));
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.QUIT:
                        PopCurrentState();
                        EndCurrentState();
                        SetCurrentState(new Quit_ApplicationState("State_Quit"));
                        isSwitch = true;
                        break;
                }

                break;

            case ApplicationState_Type.OPTIONS:
                switch (stateResquest)
                {
                    case ApplicationState_Type.MAINMENU:
                        EndCurrentState();
                        SetCurrentState(new MainMenu_ApplicationState("State_MainMenu"));
                        isSwitch = true;
                        break;
                }
                break;

            case ApplicationState_Type.CREDITS:
                switch (stateResquest)
                {

                    case ApplicationState_Type.MAINMENU:

                        EndCurrentState();
                        SetCurrentState(new MainMenu_ApplicationState("State_MainMenu"));
                        isSwitch = true;
                        break;
                }
                break;
        }
    
        // DEBUG
        if (isSwitch) Debug.Log(" State switched to:" + stateResquest);
        else Debug.Log(" State didn't switch to:" + stateResquest);

        return isSwitch;
    }

    private void EndCurrentState()
    {
        m_currentState.endMusic();
        m_currentState.end();
        m_states.Remove(m_currentState);
    }
    private void SetCurrentState(ApplicationState newState)
    {
        m_states.Add(newState);
        m_currentState = newState;
    }

    public void PopCurrentState()
    {
        m_currentState.end();
        m_states.Remove(m_currentState);
        m_currentState = m_states[m_states.Count-1];
    }

    public ApplicationState_Type Get_CurrentStateType()
    {
        return m_currentState.Type;
    }
    public ApplicationState Get_CurrentState()
    {
        return m_currentState;
    }
}

