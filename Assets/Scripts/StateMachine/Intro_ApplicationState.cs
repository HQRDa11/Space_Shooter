using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_ApplicationState : ApplicationState
{
    private float _introTime;
    public Intro_ApplicationState(string name) 
        : base (name)
    {
        _introTime = 2.6f;
        m_type = ApplicationState_Type.INTRO;
        load();
    }
    public override void load()
    {
        m_UI = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI_States/UI_Intro"));
        m_UI.transform.SetParent(m_gameObject.transform);
    }
    public override void unload()
    {
        GameObject.Destroy(m_UI);
    }
    public override void update()
    {
        base.update();
        _introTime -= Time.deltaTime;
        Debug.Log(_introTime);
        switch ( _introTime <= 0 || Input.GetKeyDown(KeyCode.Mouse0) )
        {
            case true:
                Debug.Log("condition ok");
                m_stateMachine.stateRequest(ApplicationState_Type.MAINMENU);
                break;
        }

    }

    public override void end()
    {
        unload();
    }
}
