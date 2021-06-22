using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_ApplicationState : ApplicationState
{
    private float tempTimer = 5 ;
    public Intro_ApplicationState() 
        : base ()
    {
        m_type = ApplicationState_Type.INTRO;
    }

    public override void update()
    {
        base.update();
        //Debug.Log("I am state." + m_type + " and I just updated! ");
        tempTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0)){ tempTimer = 0; }
    }

    public override void end()
    {
    }
}
