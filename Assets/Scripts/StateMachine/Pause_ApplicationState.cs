using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_ApplicationState : ApplicationState
{
    public Pause_ApplicationState(string name)
        : base(name)
    {

        m_type = ApplicationState_Type.PAUSE;
    }

    public override void update()
    {
        base.update();
    }

    public override void end()
    {

    }
}
