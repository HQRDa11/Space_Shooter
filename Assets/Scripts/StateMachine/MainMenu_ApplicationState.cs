using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_ApplicationState : ApplicationState
{
    public MainMenu_ApplicationState(string name) 
        : base(name)
    {
        m_type = ApplicationState_Type.MAINMENU;
    }

    public override void update()
    {
        base.update();
        //Debug.Log("I am state." + m_type + " and I just updated! ");
    }

    public override void end()
    {
        Debug.Log("state" + m_type + " ending! ");
    }
}
