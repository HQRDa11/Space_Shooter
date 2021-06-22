using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options_ApplicationState : ApplicationState
{
    private float tempTimer = 5;
    public Options_ApplicationState(string name)
        : base(name)
    {
        m_type = ApplicationState_Type.OPTIONS;
    }

    public override void update()
    {
        base.update();
        GameObject.FindGameObjectWithTag("ApplicationState").name = "state - Options";
        tempTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0)) { tempTimer = 0; }
    }

    public override void end()
    {
    }
}
