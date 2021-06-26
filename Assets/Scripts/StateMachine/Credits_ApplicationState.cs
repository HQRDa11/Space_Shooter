using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_ApplicationState : ApplicationState
{
    private float tempTimer = 5;
    public Credits_ApplicationState(string name)
        : base(name)
    {
        m_type = ApplicationState_Type.CREDITS;
    }

    public override void update()
    {
        base.update();
        Debug.Log("I am state." + m_type + " and I just updated! ");
        tempTimer -= Time.deltaTime;
    }

    public override void end()
    {

    }
}
