using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_ApplicationState : ApplicationState
{
    public Quit_ApplicationState()
        : base()
    {
        m_type = ApplicationState_Type.QUIT;
    }

    public override void update()
    {
        base.update();
        Debug.Log("I am state." + m_type + " and I will Quit! ");
        Debug.Log("Application.Quit()");
        Application.Quit();
    }

    public override void end()
    {
    }
}
