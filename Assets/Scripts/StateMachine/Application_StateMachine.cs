using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ApplicationState_Type { NULL, INTRO, MAINMENU, UPGRADE, GAME, PAUSE, OPTIONS, CREDITS, QUIT }
public class Application_StateMachine : MonoBehaviour
{
    private List<ApplicationState> m_states;
    private ApplicationState m_currentState;

    public void Awake()
    {
        m_states = new List<ApplicationState>();
        m_states.Add(new Intro_ApplicationState());
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
                        SetCurrentState(new MainMenu_ApplicationState());
                        isSwitch = true;
                        break;
                }

                break;

            case ApplicationState_Type.MAINMENU:

                switch (stateResquest)
                {
                    case ApplicationState_Type.GAME:
                        EndCurrentState();
                        SetCurrentState(new Game_ApplicationState());
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.OPTIONS:
                        EndCurrentState();
                        SetCurrentState(new Options_ApplicationState());
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.CREDITS:
                        EndCurrentState();
                        SetCurrentState(new Credits_ApplicationState());
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.QUIT:
                        EndCurrentState();
                        //for each states s in m_states s.end?
                        SetCurrentState(new Quit_ApplicationState());
                        isSwitch = true;
                        break;
                }

                break;

            case ApplicationState_Type.GAME:

                switch (stateResquest)
                {
                    case ApplicationState_Type.PAUSE:
                        SetCurrentState(new InGameMenu_ApplicationState());
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
                        SetCurrentState(new MainMenu_ApplicationState());
                        isSwitch = true;
                        break;

                    case ApplicationState_Type.QUIT:
                        PopCurrentState();
                        EndCurrentState();
                        SetCurrentState(new Quit_ApplicationState());
                        isSwitch = true;
                        break;
                }

                break;

            case ApplicationState_Type.OPTIONS:
                switch (stateResquest)
                {
                    case ApplicationState_Type.MAINMENU:
                        EndCurrentState();
                        SetCurrentState(new MainMenu_ApplicationState());
                        isSwitch = true;
                        break;
                }
                break;

            case ApplicationState_Type.CREDITS:
                switch (stateResquest)
                {

                    case ApplicationState_Type.MAINMENU:

                        EndCurrentState();
                        SetCurrentState(new MainMenu_ApplicationState());
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
}