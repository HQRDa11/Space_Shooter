using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_ApplicationState : ApplicationState
{
    public MainMenu_ApplicationState(string name) 
        : base(name)
    {
        m_type = ApplicationState_Type.MAINMENU;
        m_UI = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI_States/UI_MainMenu"));
        m_UI.transform.SetParent(GameObject.Find("State_MainMenu").gameObject.transform);
    }

    public override void update()
    {
        base.update();
        //Debug.Log("I am state." + m_type + " and I just updated! ");
    }

    public override void end()
    {
        GameObject.Destroy(m_UI);
        //Debug.Log("state" + m_type + " ending! ");
    }

    public override float GetMainThemeSchedule()
    {
        return 0;
    }
}

