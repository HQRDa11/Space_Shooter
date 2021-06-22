using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu_ApplicationState : ApplicationState
{
    public InGameMenu_ApplicationState()
        : base()
    {

        m_type = ApplicationState_Type.PAUSE;
    }

    public override void update()
    {
        base.update();
        Debug.Log("I am state." + m_type + " and I just updated! ");
    }

    public override void end()
    {

    }
}
