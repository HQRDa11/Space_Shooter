using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationState 
{
    protected ApplicationState_Type m_type;
    protected GameObject m_gameObject;
    protected GameObject m_UI;
    protected Application_StateMachine m_stateMachine;
    protected bool m_waitUserEntry;
    public ApplicationState_Type Type { get {return m_type; } }

    public ApplicationState(string name)
    {
        if(!(m_stateMachine = GameObject.FindObjectOfType<Application_StateMachine>()))
        {
            Debug.LogError("Can't Find Application StateMachine");
        }

        m_gameObject = GameObject.FindGameObjectWithTag("ApplicationState");
        m_gameObject.name = name;
    }


    public virtual void load()
    {

    }
    public virtual void unload()
    {

    }
    public virtual void update()
    {
        //Debug.Log("state." + m_type + " update...");
    }

    public virtual void end()
    {

    }

    public void endMusic()
    {
        MusicPlayer musicPlayer = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
        musicPlayer.Stop();
        //Debug.Log("isMusicPlayerEnding? " + (musicPlayer == true));
        //Debug.Log("state." + m_type + " ending...");
    }

    public virtual float GetMainThemeSchedule()
    {
        return 0;
    }

    public virtual ApplicationState_Type Next()
    {
        return ApplicationState_Type.NULL;
    }
    public virtual ApplicationState_Type Previous()
    {
        return ApplicationState_Type.NULL;
    }

    public virtual void WaitUserEntry() // Tell the state to wait the next user entry (eg. click) to call next state. 
    {
        m_waitUserEntry = true;
    }
}
